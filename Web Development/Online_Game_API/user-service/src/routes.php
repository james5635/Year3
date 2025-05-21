<?php
/**
 * User Service - Routes
 *
 * This file defines all the routes and handlers for the User Service.
 * It includes endpoints for user registration, authentication, and profile management.
 * JWT authentication is implemented for protected routes.
 */

use Slim\App;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler; // <--- Add this use statement
use Respect\Validation\Validator as v;
use Firebase\JWT\JWT;
use Firebase\JWT\Key;

return function (App $app) {

    $pdo = new PDO(
        "mysql:host=" . $_ENV['DB_HOST'] . ";dbname=" . $_ENV['DB_NAME'] . ";charset=utf8mb4",
        $_ENV['DB_USER'],
        $_ENV['DB_PASS']
    );
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC);

    // Middleware for JWT authentication
    // CORRECTED SIGNATURE FOR SLIM 4 / PSR-15 MIDDLEWARE
    $authMiddleware = function (Request $request, RequestHandler $handler): Response {

        $authHeader = $request->getHeaderLine('Authorization');
        if (empty($authHeader)) {
            // Create a new response object to return the error
            $response = new \Slim\Psr7\Response(); // Or use $handler->handle($request) and then modify its response
            $response->getBody()->write(json_encode(['message' => 'Authorization header missing.']));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        }

        list($type, $token) = explode(' ', $authHeader, 2);
        if (strtolower($type) !== 'bearer' || empty($token)) {
            $response = new \Slim\Psr7\Response();
            $response->getBody()->write(json_encode(['message' => 'Invalid token format.']));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        }

        try {
            $secretKey = $_ENV['JWT_SECRET_KEY'];
            $decoded = JWT::decode($token, new Key($secretKey, 'HS256'));
            $request = $request->withAttribute('user', $decoded); // Add user info to request

            // Call the next handler in the pipeline
            return $handler->handle($request); // <--- Corrected call
        } catch (Firebase\JWT\SignatureInvalidException $e) {
            $response = new \Slim\Psr7\Response();
            $response->getBody()->write(json_encode(['message' => 'Invalid token signature.']));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        } catch (Firebase\JWT\ExpiredException $e) {
            $response = new \Slim\Psr7\Response();
            $response->getBody()->write(json_encode(['message' => 'Token has expired.']));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        } catch (Exception $e) {
            $response = new \Slim\Psr7\Response();
            $response->getBody()->write(json_encode(['message' => 'Invalid token: ' . $e->getMessage()]));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        }
    };


    $app->post('/register', function (Request $request, Response $response) use ($pdo) {
        $data = $request->getParsedBody();

        $username = $data['username'] ?? '';
        $email = $data['email'] ?? '';
        $password = $data['password'] ?? '';

        // Validate input
        if (!v::stringType()->length(3, 20)->validate($username) ||
            !v::email()->validate($email) ||
            !v::stringType()->length(6, 50)->validate($password)) {
            $response->getBody()->write(json_encode(['message' => 'Invalid input data.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $stmt = $pdo->prepare("SELECT COUNT(*) FROM users WHERE username = ? OR email = ?");
            $stmt->execute([$username, $email]);
            if ($stmt->fetchColumn() > 0) {
                $response->getBody()->write(json_encode(['message' => 'Username or email already exists.']));
                return $response->withStatus(409)->withHeader('Content-Type', 'application/json');
            }

            $passwordHash = password_hash($password, PASSWORD_BCRYPT);
            $stmt = $pdo->prepare("INSERT INTO users (username, email, password_hash) VALUES (?, ?, ?)");
            $stmt->execute([$username, $email, $passwordHash]);

            $response->getBody()->write(json_encode(['message' => 'User registered successfully.']));
            return $response->withStatus(201)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/login', function (Request $request, Response $response) use ($pdo) {
        $data = $request->getParsedBody();
        $usernameOrEmail = $data['usernameOrEmail'] ?? '';
        $password = $data['password'] ?? '';

        if (empty($usernameOrEmail) || empty($password)) {
            $response->getBody()->write(json_encode(['message' => 'Username/Email and password are required.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $stmt = $pdo->prepare("SELECT id, username, password_hash FROM users WHERE username = ? OR email = ?");
            $stmt->execute([$usernameOrEmail, $usernameOrEmail]);
            $user = $stmt->fetch();

            if (!$user || !password_verify($password, $user['password_hash'])) {
                $response->getBody()->write(json_encode(['message' => 'Invalid credentials.']));
                return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
            }

            // Generate JWT Token
            $secretKey = $_ENV['JWT_SECRET_KEY'];
            $issuedAt = time();
            $expirationTime = $issuedAt + 3600; // token valid for 1 hour

            $payload = [
                'iat' => $issuedAt,
                'exp' => $expirationTime,
                'userId' => $user['id'],
                'username' => $user['username']
            ];

            $jwt = JWT::encode($payload, $secretKey, 'HS256');

            $response->getBody()->write(json_encode([
                'message' => 'Login successful.',
                'token' => $jwt,
                'userId' => $user['id'],
                'username' => $user['username']
            ]));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        } catch (Exception $e) {
            $response->getBody()->write(json_encode(['message' => 'Token generation error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    });


    $app->get('/profile', function (Request $request, Response $response) use ($pdo) {
        $user = $request->getAttribute('user'); // User data from middleware
        if (!$user) {
            $response->getBody()->write(json_encode(['message' => 'User not authenticated.']));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        }

        try {
            $stmt = $pdo->prepare("SELECT id, username, email FROM users WHERE id = ?");
            $stmt->execute([$user->userId]);
            $profile = $stmt->fetch();

            if (!$profile) {
                $response->getBody()->write(json_encode(['message' => 'User profile not found.']));
                return $response->withStatus(404)->withHeader('Content-Type', 'application/json');
            }

            $response->getBody()->write(json_encode($profile));
            return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    })->add($authMiddleware); // Apply authentication middleware

    $app->put('/profile', function (Request $request, Response $response) use ($pdo) {
        $user = $request->getAttribute('user');
        if (!$user) {
            $response->getBody()->write(json_encode(['message' => 'User not authenticated.']));
            return $response->withStatus(401)->withHeader('Content-Type', 'application/json');
        }

        $data = $request->getParsedBody();
        $username = $data['username'] ?? null;
        $email = $data['email'] ?? null;

        if (empty($username) && empty($email)) {
            $response->getBody()->write(json_encode(['message' => 'No data provided for update.']));
            return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
        }

        try {
            $updates = [];
            $params = [];
            if ($username) {
                if (!v::stringType()->length(3, 20)->validate($username)) {
                    $response->getBody()->write(json_encode(['message' => 'Invalid username format.']));
                    return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
                }
                $updates[] = "username = ?";
                $params[] = $username;
            }
            if ($email) {
                if (!v::email()->validate($email)) {
                    $response->getBody()->write(json_encode(['message' => 'Invalid email format.']));
                    return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
                }
                $updates[] = "email = ?";
                $params[] = $email;
            }

            if (!empty($updates)) {
                $sql = "UPDATE users SET " . implode(', ', $updates) . " WHERE id = ?";
                $params[] = $user->userId;
                $stmt = $pdo->prepare($sql);
                $stmt->execute($params);
                $response->getBody()->write(json_encode(['message' => 'Profile updated successfully.']));
                return $response->withStatus(200)->withHeader('Content-Type', 'application/json');
            } else {
                $response->getBody()->write(json_encode(['message' => 'No valid fields to update.']));
                return $response->withStatus(400)->withHeader('Content-Type', 'application/json');
            }
        } catch (PDOException $e) {
            $response->getBody()->write(json_encode(['message' => 'Database error: ' . $e->getMessage()]));
            return $response->withStatus(500)->withHeader('Content-Type', 'application/json');
        }
    })->add($authMiddleware);

    // Health check endpoint
    $app->get('/health', function (Request $request, Response $response) {
        $response->getBody()->write(json_encode(['status' => 'User Service Healthy']));
        return $response->withHeader('Content-Type', 'application/json');
    });
};