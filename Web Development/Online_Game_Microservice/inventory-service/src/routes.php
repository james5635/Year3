<?php

use Slim\App;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;

return function (App $app) {

    $pdo = new PDO(
        "mysql:host=" . $_ENV['DB_HOST'] . ";dbname=" . $_ENV['DB_NAME'] . ";charset=utf8mb4",
        $_ENV['DB_USER'],
        $_ENV['DB_PASS']
    );
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);

    // --- Item Definitions (Admin-like operations) ---
    $app->get('/items', function (Request $request, Response $response) use ($pdo) {
        try {
            $stmt = $pdo->query("SELECT * FROM items");
            $items = $stmt->fetchAll();
            $response->getBody()->write(json_encode($items));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/items', function (Request $request, Response $response) use ($pdo) {
        $data = $request->getParsedBody();
        $name = $data['name'] ?? '';
        $description = $data['description'] ?? null;
        $type = $data['type'] ?? 'misc';
        $rarity = $data['rarity'] ?? 'common';
        $value = $data['value'] ?? 0;

        if (empty($name)) {
            $response->getBody()->write(json_encode(['message' => 'Item name is required.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $stmt = $pdo->prepare("INSERT INTO items (name, description, type, rarity, value) VALUES (?, ?, ?, ?, ?)");
            $stmt->execute([$name, $description, $type, $rarity, $value]);
            $itemId = $pdo->lastInsertId();
            $response->getBody()->write(json_encode(['message' => 'Item created successfully.', 'item_id' => $itemId]));
            return $response->withStatus(201)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            if ($e->getCode() === '23000') { // Duplicate entry
                $response->getBody()->write(json_encode(['message' => 'Item with this name already exists.']));
                return $response->withStatus(409)->withHeader('Content-Type', 'application/json');
            }
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    // --- User Inventory Management ---
    $app->get('/inventory/{userId}', function (Request $request, Response $response, array $args) use ($pdo) {
        $userId = $args['userId'];

        try {
            $stmt = $pdo->prepare("SELECT ui.quantity, i.id AS item_id, i.name, i.description, i.type, i.rarity, i.value FROM user_inventory ui JOIN items i ON ui.item_id = i.id WHERE ui.user_id = ?");
            $stmt->execute([$userId]);
            $inventory = $stmt->fetchAll();

            $response->getBody()->write(json_encode($inventory));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/inventory/{userId}/add', function (Request $request, Response $response, array $args) use ($pdo) {
        $userId = $args['userId'];
        $data = $request->getParsedBody();
        $itemId = $data['item_id'] ?? 0;
        $quantity = $data['quantity'] ?? 1;

        if ($itemId <= 0 || $quantity <= 0) {
            $response->getBody()->write(json_encode(['message' => 'Invalid item ID or quantity.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            // Check if item exists
            $stmt = $pdo->prepare("SELECT id FROM items WHERE id = ?");
            $stmt->execute([$itemId]);
            if (!$stmt->fetch()) {
                $response->getBody()->write(json_encode(['message' => 'Item not found.']));
                return $response->withStatus(404)->withHeader('Content-Type', 'application/json');
            }

            // Upsert: Insert if not exists, update quantity if exists
            $stmt = $pdo->prepare("
                INSERT INTO user_inventory (user_id, item_id, quantity)
                VALUES (?, ?, ?)
                ON DUPLICATE KEY UPDATE quantity = quantity + VALUES(quantity)
            ");
            $stmt->execute([$userId, $itemId, $quantity]);

            $response->getBody()->write(json_encode(['message' => 'Item(s) added to inventory.']));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/inventory/{userId}/remove', function (Request $request, Response $response, array $args) use ($pdo) {
        $userId = $args['userId'];
        $data = $request->getParsedBody();
        $itemId = $data['item_id'] ?? 0;
        $quantityToRemove = $data['quantity'] ?? 1;

        if ($itemId <= 0 || $quantityToRemove <= 0) {
            $response->getBody()->write(json_encode(['message' => 'Invalid item ID or quantity.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $pdo->beginTransaction();

            // Get current quantity
            $stmt = $pdo->prepare("SELECT quantity FROM user_inventory WHERE user_id = ? AND item_id = ?");
            $stmt->execute([$userId, $itemId]);
            $currentQuantity = $stmt->fetchColumn();

            if ($currentQuantity === false || $currentQuantity < $quantityToRemove) {
                $pdo->rollBack();
                $response->getBody()->write(json_encode(['message' => 'Not enough items in inventory or item not found.']));
                return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
            }

            if ($currentQuantity - $quantityToRemove <= 0) {
                // Remove the entry if quantity drops to 0 or less
                $stmt = $pdo->prepare("DELETE FROM user_inventory WHERE user_id = ? AND item_id = ?");
                $stmt->execute([$userId, $itemId]);
            } else {
                // Decrease quantity
                $stmt = $pdo->prepare("UPDATE user_inventory SET quantity = quantity - ? WHERE user_id = ? AND item_id = ?");
                $stmt->execute([$quantityToRemove, $userId, $itemId]);
            }

            $pdo->commit();
            $response->getBody()->write(json_encode(['message' => 'Item(s) removed from inventory.']));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $pdo->rollBack();
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    // Health check endpoint
    $app->get('/health', function (Request $request, Response $response) {
        $response->getBody()->write(json_encode(['status' => 'Inventory Service Healthy']));
        return $response->withHeader('Content-Type', 'application/json');
    });
};