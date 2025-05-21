<?php
/**
 * Mathematics Topics API
 * 
 * This file serves as the main entry point for the RESTful API that manages
 * mathematics topics. It handles GET, POST, PUT, and DELETE requests for
 * retrieving, creating, updating, and deleting math topics from the database.
 */

header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
// header("Access-Control-Allow-Origin: http://localhost:5173");
header("Access-Control-Allow-Methods: GET, POST, PUT, DELETE");
header("Access-Control-Allow-Headers: Content-Type");

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
            echo json_encode($result);
        }
        break;
    case "POST":
        $data = json_decode(file_get_contents("php://input"), true);
        if (
            isset(
                $data["topic_name"],
                $data["category"],
                $data["sub_category"],
                $data["description"],
                $data["difficulty_level"]
            )
        ) {
            $sql = $conn->prepare(
                "INSERT INTO MathTopics (topic_name, category, sub_category, description, difficulty_level) VALUES (:topic_name, :category, :sub_category, :description, :difficulty_level)"
            );
            $sql->execute([
                ":topic_name" => $data["topic_name"],
                ":category" => $data["category"],
                ":sub_category" => $data["sub_category"],
                ":description" => $data["description"],
                ":difficulty_level" => $data["difficulty_level"],
            ]);
            echo json_encode(["message" => "Topic created successfully"]);
        } else {
            echo json_encode(["message" => "Invalid data"]);
        }
        break;
    case "PUT":
        $data = json_decode(file_get_contents("php://input"), true);
        if (isset($_GET["id"]) && is_array($data) && !empty($data)) {
            $allowedFields = [
                "topic_name",
                "category",
                "sub_category",
                "description",
                "difficulty_level",
                "is_active",
            ];

            $updates = array_intersect_key($data, array_flip($allowedFields));
            if (empty($updates)) {
                echo json_encode(["message" => "No valid fields to update"]);
                break;
            }

            $setStatements = [];
            $params = [":id" => $_GET["id"]];

            foreach ($updates as $field => $value) {
                $setStatements[] = "$field = :$field";
                $params[":$field"] = $value;
            }

            $sql = $conn->prepare(
                "UPDATE MathTopics SET " .
                    implode(", ", $setStatements) .
                    " WHERE id = :id"
            );

            if ($sql->execute($params)) {
                echo json_encode(["message" => "Topic updated successfully"]);
            } else {
                echo json_encode(["message" => "Failed to update topic"]);
            }
        } else {
            echo json_encode(["message" => "Invalid data or missing ID"]);
        }
        break;
    case "DELETE":
        $data = json_decode(file_get_contents("php://input"), true);
        if (isset($_GET["id"])) {
            $sql = $conn->prepare("DELETE FROM MathTopics WHERE id = :id");
            $sql->execute([
                ":id" => $_GET["id"],
            ]);
            if ($sql->rowCount() > 0) {
                echo json_encode(["message" => "Topic deleted successfully"]);
            } else {
                echo json_encode(["message" => "Failed to delete topic"]);
            }
        } else {
            echo json_encode(["message" => "id is required"]);
        }
        break;
    default:
        echo json_encode(["message" => "Invalid method"]);
        break;
}

?>
