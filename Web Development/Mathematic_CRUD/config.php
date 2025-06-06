<?php
/**
 * Configuration File
 * 
 * This file loads environment variables from .env file using phpdotenv
 * and returns database configuration parameters for the application.
 */

require_once __DIR__ . "/vendor/autoload.php";

if (file_exists(__DIR__ . "/.env")) {
    $dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
    $dotenv->load();
}

return [
    "app_env" => $_ENV["APP_ENV"] ,
    "host" => $_ENV["HOST"] ,
    "port" => $_ENV["PORT"] ,
    "username" => $_ENV["USER"] ,
    "password" => $_ENV["PASS"] ,
];
