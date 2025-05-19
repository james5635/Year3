<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: GET, POST, PUT, DELETE");

require_once "db.php";
$conn = getConnection();

$method = $_SERVER["REQUEST_METHOD"];

switch ($method) {
    case "GET":
        if (isset($_GET["id"])) {
            $sql = $conn->prepare("SELECT * FROM MathTopics WHERE id = :id");
            $sql->execute([":id" => $_GET["id"]]);
            $result = $sql->fetch(PDO::FETCH_ASSOC);
            echo json_encode($result ?: ["message" => "No topic found"]);
        } else {
            $sql = $conn->prepare("SELECT * FROM MathTopics");
            $sql->execute();
            $result = $sql->fetchAll(PDO::FETCH_ASSOC);
            echo json_encode($result );
        }
        break;
    case "POST":
        // Handle POST request
        break;
    case "PUT":
        // Handle PUT request
        break;
    case "DELETE":
        // Handle DELETE request
        break;
    default:
        // Handle invalid method
        break;
}

?>
