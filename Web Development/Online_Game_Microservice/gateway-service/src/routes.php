<?php

use Slim\App;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\RequestException;
use Slim\Routing\RouteCollectorProxy; // Import the RouteCollectorProxy

return function (App $app) {

    $app->post('/register', function (Request $request, Response $response) {
        $client = new Client();
        $userServiceUrl = $_ENV['USER_SERVICE_URL']; // e.g., http://user-service:8001
        $data = $request->getParsedBody();

        try {
            $res = $client->post("$userServiceUrl/register", ['json' => $data]);
            $response->getBody()->write($res->getBody()->getContents());
            return $response->withStatus($res->getStatusCode())->withHeader('Content-Type', 'application/json');
        } catch (RequestException $e) {
            $statusCode = $e->hasResponse() ? $e->getResponse()->getStatusCode() : 500;
            $errorBody = $e->hasResponse() ? $e->getResponse()->getBody()->getContents() : json_encode(['message' => 'Internal Server Error']);
            $response->getBody()->write($errorBody);
            return $response->withStatus($statusCode)->withHeader('Content-Type', 'application/json');
        }
    });

    $app->post('/login', function (Request $request, Response $response) {
        $client = new Client();
        $userServiceUrl = $_ENV['USER_SERVICE_URL'];
        $data = $request->getParsedBody();

        try {
            $res = $client->post("$userServiceUrl/login", ['json' => $data]);
            $response->getBody()->write($res->getBody()->getContents());
            return $response->withStatus($res->getStatusCode())->withHeader('Content-Type', 'application/json');
        } catch (RequestException $e) {
            $statusCode = $e->hasResponse() ? $e->getResponse()->getStatusCode() : 500;
            $errorBody = $e->hasResponse() ? $e->getResponse()->getBody()->getContents() : json_encode(['message' => 'Internal Server Error']);
            $response->getBody()->write($errorBody);
            return $response->withStatus($statusCode)->withHeader('Content-Type', 'application/json');
        }
    });

    // --- Protected Routes (add an authentication middleware later) ---
    // For simplicity, we're directly calling here. In a real app, you'd
    // have a middleware to validate JWT/token before proxying.

    $app->get('/profile', function (Request $request, Response $response) {
        $client = new Client();
        $userServiceUrl = $_ENV['USER_SERVICE_URL'];
        // In a real app, pass the JWT token from the client to the user-service
        $headers = $request->getHeaders(); // Get all headers
        $authorizationHeader = $headers['Authorization'][0] ?? null; // Get Authorization header

        try {
            $res = $client->get("$userServiceUrl/profile", ['headers' => ['Authorization' => $authorizationHeader]]);
            $response->getBody()->write($res->getBody()->getContents());
            return $response->withStatus($res->getStatusCode())->withHeader('Content-Type', 'application/json');
        } catch (RequestException $e) {
            $statusCode = $e->hasResponse() ? $e->getResponse()->getStatusCode() : 500;
            $errorBody = $e->hasResponse() ? $e->getResponse()->getBody()->getContents() : json_encode(['message' => 'Internal Server Error']);
            $response->getBody()->write($errorBody);
            return $response->withStatus($statusCode)->withHeader('Content-Type', 'application/json');
        }
    });

    // Corrected /lobbies group
    $app->group('/lobbies', function (RouteCollectorProxy $group) { // Change type hint to RouteCollectorProxy
        // Remove the 'echo "hi";' as it's not appropriate in a route definition
        $gameLobbyServiceUrl = $_ENV['GAME_LOBBY_SERVICE_URL'];
        $client = new Client();

        $group->get('', function (Request $request, Response $response) use ($client, $gameLobbyServiceUrl) {
            try {
                $res = $client->get("$gameLobbyServiceUrl/lobbies");
                $response->getBody()->write($res->getBody()->getContents());
                return $response->withStatus($res->getStatusCode())->withHeader('Content-Type', 'application/json');
            } catch (RequestException $e) {
                $statusCode = $e->hasResponse() ? $e->getResponse()->getStatusCode() : 500;
                $errorBody = $e->hasResponse() ? $e->getResponse()->getBody()->getContents() : json_encode(['message' => 'Internal Server Error']);
                $response->getBody()->write($errorBody);
                return $response->withStatus($statusCode)->withHeader('Content-Type', 'application/json');
            }
        });

        $group->post('', function (Request $request, Response $response) use ($client, $gameLobbyServiceUrl) {
            $data = $request->getParsedBody();
            try {
                $res = $client->post("$gameLobbyServiceUrl/lobbies", ['json' => $data]);
                $response->getBody()->write($res->getBody()->getContents());
                return $response->withStatus($res->getStatusCode())->withHeader('Content-Type', 'application/json');
            } catch (RequestException $e) {
                $statusCode = $e->hasResponse() ? $e->getResponse()->getStatusCode() : 500;
                $errorBody = $e->hasResponse() ? $e->getResponse()->getBody()->getContents() : json_encode(['message' => 'Internal Server Error']);
                $response->getBody()->write($errorBody);
                return $response->withStatus($statusCode)->withHeader('Content-Type', 'application/json');
            }
        });
    });

    $app->get('/inventory/{userId}', function (Request $request, Response $response, array $args) {
        $client = new Client();
        $inventoryServiceUrl = $_ENV['INVENTORY_SERVICE_URL'];
        $userId = $args['userId'];

        try {
            $res = $client->get("$inventoryServiceUrl/inventory/$userId");
            $response->getBody()->write($res->getBody()->getContents());
            return $response->withStatus($res->getStatusCode())->withHeader('Content-Type', 'application/json');
        } catch (RequestException $e) {
            $statusCode = $e->hasResponse() ? $e->getResponse()->getStatusCode() : 500;
            $errorBody = $e->hasResponse() ? $e->getResponse()->getBody()->getContents() : json_encode(['message' => 'Internal Server Error']);
            $response->getBody()->write($errorBody);
            return $response->withStatus($statusCode)->withHeader('Content-Type', 'application/json');
        }
    });

    // Health check endpoint
    $app->get('/health', function (Request $request, Response $response) {
        $response->getBody()->write(json_encode(['status' => 'Gateway Service Healthy']));
        return $response->withHeader('Content-Type', 'application/json');
    });
};
