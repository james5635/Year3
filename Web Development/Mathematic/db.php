<?php
// require_once for class, function, constant
// require for template, configuration variable, return value, ...
function getConnection(): PDO
{
    $config = require "config.php";
    $conn = new PDO("mysql:host={$config['host']};port={$config['port']};dbname=Math", $config['username'], $config['password']);
    // optional:  PDO::ERRMODE_EXCEPTION by default
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    return $conn;
}

?>
