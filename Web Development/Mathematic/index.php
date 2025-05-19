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
        // not working
        // parse_str(file_get_contents("php://input"), $data);
        $data = json_decode(file_get_contents("php://input"), true);

        // echo $_GET["id"];
        // echo $data["topic_name"];
        // echo $data["category"];
        // echo $data["sub_category"];
        // echo $data["description"];
        // echo $data["difficulty_level"];
        if (
            isset(
                $_GET["id"],
                $data["topic_name"],
                $data["category"],
                $data["sub_category"],
                $data["description"],
                $data["difficulty_level"],
                $data["created_at"],
                $data["updated_at"],
                $data["is_active"]
            )
        ) {
            $sql = $conn->prepare(
                "UPDATE MathTopics SET topic_name = :topic_name, category = :category, sub_category = :sub_category, description = :description, difficulty_level = :difficulty_level, created_at = :created_at, updated_at = :updated_at, is_active = :is_active WHERE id = :id"
            );
            $sql->execute([
                ":id" => $_GET["id"],
                ":topic_name" => $data["topic_name"],
                ":category" => $data["category"],
                ":sub_category" => $data["sub_category"],
                ":description" => $data["description"],
                ":difficulty_level" => $data["difficulty_level"],
                ":created_at" => $data["created_at"],
                ":updated_at" => $data["updated_at"],
                ":is_active" => $data["is_active"],
            ]);
            echo json_encode(["message" => "Topic updated successfully"]);
        } else {
            echo json_encode(["message" => "Invalid data"]);
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
