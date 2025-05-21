<?php
/**
 * Inventory Service - Main Entry Point
 *
 * This file serves as the entry point for the Inventory Service in the Online Game API.
 * It initializes the Slim application, loads environment variables, and registers routes.
 */

use Slim\Factory\AppFactory;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Dotenv\Dotenv;

require __DIR__ . '/../vendor/autoload.php';

if (file_exists(__DIR__ . '/../.env')) {
    $dotenv = Dotenv::createImmutable(__DIR__ . '/../');
    $dotenv->load();
}

$app = AppFactory::create();

$app->addBodyParsingMiddleware();
$app->addErrorMiddleware(true, true, true);

// Include routes
(require __DIR__ . '/../src/routes.php')($app);

$app->run();