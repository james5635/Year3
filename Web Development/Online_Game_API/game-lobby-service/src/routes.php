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

    $app->get('/lobbies', function (Request $request, Response $response) use ($pdo) {
        try {
            $stmt = $pdo->query("SELECT * FROM lobbies WHERE status = 'waiting' OR status = 'playing'");
            $lobbies = $stmt->fetchAll();
            $response->getBody()->write(json_encode($lobbies));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/lobbies', function (Request $request, Response $response) use ($pdo) {
        $data = $request->getParsedBody();
        $name = $data['name'] ?? '';
        $maxPlayers = $data['max_players'] ?? 0;
        $createdByUserId = $data['created_by_user_id'] ?? 0; // This should come from auth token in real app

        if (empty($name) || $maxPlayers <= 0 || $createdByUserId <= 0) {
            $response->getBody()->write(json_encode(['message' => 'Invalid lobby data.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $stmt = $pdo->prepare("INSERT INTO lobbies (name, max_players, created_by_user_id) VALUES (?, ?, ?)");
            $stmt->execute([$name, $maxPlayers, $createdByUserId]);
            $lobbyId = $pdo->lastInsertId();

            // Automatically join the creator to the lobby
            $stmt = $pdo->prepare("INSERT INTO lobby_players (lobby_id, user_id) VALUES (?, ?)");
            $stmt->execute([$lobbyId, $createdByUserId]);

            $response->getBody()->write(json_encode(['message' => 'Lobby created successfully.', 'lobby_id' => $lobbyId]));
            return $response->withStatus(201)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/lobbies/{lobbyId}/join', function (Request $request, Response $response, array $args) use ($pdo) {
        $lobbyId = $args['lobbyId'];
        $data = $request->getParsedBody();
        $userId = $data['user_id'] ?? 0; // This should come from auth token in real app

        if ($userId <= 0) {
            $response->getBody()->write(json_encode(['message' => 'Invalid user ID.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            // Check if lobby exists and is not full
            $stmt = $pdo->prepare("SELECT max_players, current_players FROM lobbies WHERE id = ? AND (status = 'waiting' OR status = 'playing')");
            $stmt->execute([$lobbyId]);
            $lobby = $stmt->fetch();

            if (!$lobby) {
                $response->getBody()->write(json_encode(['message' => 'Lobby not found or not joinable.']));
                return $response->withStatus(404)->withHeader('Content-Type', 'application/json');
            }

            if ($lobby['current_players'] >= $lobby['max_players']) {
                $response->getBody()->write(json_encode(['message' => 'Lobby is full.']));
                return $response->withStatus(409)->withHeader('Content-Type', 'application/json');
            }

            // Check if user is already in this lobby
            $stmt = $pdo->prepare("SELECT COUNT(*) FROM lobby_players WHERE lobby_id = ? AND user_id = ?");
            $stmt->execute([$lobbyId, $userId]);
            if ($stmt->fetchColumn() > 0) {
                $response->getBody()->write(json_encode(['message' => 'User already in this lobby.']));
                return $response->withStatus(409)->withHeader('Content-Type', 'application/json');
            }

            $pdo->beginTransaction();

            $stmt = $pdo->prepare("INSERT INTO lobby_players (lobby_id, user_id) VALUES (?, ?)");
            $stmt->execute([$lobbyId, $userId]);

            $stmt = $pdo->prepare("UPDATE lobbies SET current_players = current_players + 1 WHERE id = ?");
            $stmt->execute([$lobbyId]);

            $pdo->commit();

            $response->getBody()->write(json_encode(['message' => 'Successfully joined lobby.']));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $pdo->rollBack();
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/lobbies/{lobbyId}/leave', function (Request $request, Response $response, array $args) use ($pdo) {
        $lobbyId = $args['lobbyId'];
        $data = $request->getParsedBody();
        $userId = $data['user_id'] ?? 0; // This should come from auth token

        if ($userId <= 0) {
            $response->getBody()->write(json_encode(['message' => 'Invalid user ID.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $pdo->beginTransaction();

            $stmt = $pdo->prepare("DELETE FROM lobby_players WHERE lobby_id = ? AND user_id = ?");
            $stmt->execute([$lobbyId, $userId]);

            if ($stmt->rowCount() > 0) {
                $stmt = $pdo->prepare("UPDATE lobbies SET current_players = current_players - 1 WHERE id = ? AND current_players > 0");
                $stmt->execute([$lobbyId]);

                // Optional: Delete lobby if no players left (or if created_by_user_id leaves)
                $stmt = $pdo->prepare("SELECT current_players FROM lobbies WHERE id = ?");
                $stmt->execute([$lobbyId]);
                $lobby = $stmt->fetch();
                if ($lobby && $lobby['current_players'] === 0) {
                    $stmt = $pdo->prepare("DELETE FROM lobbies WHERE id = ?");
                    $stmt->execute([$lobbyId]);
                }

                $pdo->commit();
                $response->getBody()->write(json_encode(['message' => 'Successfully left lobby.']));
                return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
            } else {
                $pdo->rollBack();
                $response->getBody()->write(json_encode(['message' => 'User not found in this lobby.']));
                return $response->withStatus(404)->withHeader('Content-Type', 'application/json');
            }
        } catch (PDOException $e) {
            $pdo->rollBack();
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    // Health check endpoint
    $app->get('/health', function (Request $request, Response $response) {
        $response->getBody()->write(json_encode(['status' => 'Game Lobby Service Healthy']));
        return $response->withHeader('Content-Type', 'application/json');
    });
};