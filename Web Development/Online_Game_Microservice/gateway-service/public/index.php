<?php

use Slim\Factory\AppFactory;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Dotenv\Dotenv;

require __DIR__ . '/../vendor/autoload.php';

// Load .env variables
$dotenv = Dotenv::createImmutable(__DIR__ . '/../');
$dotenv->load();

$app = AppFactory::create();

// Add Body Parsing Middleware
$app->addBodyParsingMiddleware();

// Error Handling Middleware
$app->addErrorMiddleware(true, true, true);

// Include routes
(require __DIR__ . '/../src/routes.php')($app);

$app->run();