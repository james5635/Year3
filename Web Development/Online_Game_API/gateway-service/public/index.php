<?php
/**
 * Gateway Service - Main Entry Point
 *
 * This file serves as the entry point for the Gateway Service in the Online Game API.
 * It initializes the Slim application, loads environment variables, and registers routes.
 * The Gateway Service acts as an API gateway to route requests to appropriate microservices.
 */

use Slim\Factory\AppFactory;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Dotenv\Dotenv;

require __DIR__ . '/../vendor/autoload.php';

// Load .env variables
if (file_exists(__DIR__ . '/../.env')) {
    $dotenv = Dotenv::createImmutable(__DIR__ . '/../');
    $dotenv->load();
}

$app = AppFactory::create();

// Add Body Parsing Middleware
$app->addBodyParsingMiddleware();

// Error Handling Middleware
$app->addErrorMiddleware(true, true, true);

// Include routes
(require __DIR__ . '/../src/routes.php')($app);

$app->run();