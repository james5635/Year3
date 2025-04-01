<?php
require_once "connectDB.php";
global $conn;

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $album_title = $_POST["album_title"];
    $artist_id = $_POST["artist_id"];
    $release_date = $_POST["release_date"];
    $genre = $_POST["genre"];

    // Handle image upload
    $target_dir = "uploads/albums/";
    $cover_image = ""; // Default to empty

    if (!empty($_FILES["cover_image"]["name"])) {
        $file_name = basename($_FILES["cover_image"]["name"]);
        $file_ext = strtolower(pathinfo($file_name, PATHINFO_EXTENSION));
        $allowed_exts = ["jpg", "jpeg", "png", "gif"];
        $max_file_size = 5 * 1024 * 1024; // 5MB

        if (in_array($file_ext, $allowed_exts) && $_FILES["cover_image"]["size"] <= $max_file_size) {
            // Rename file with timestamp to avoid duplicates
            $new_file_name = time() . "_" . preg_replace("/[^a-zA-Z0-9.-]/", "_", $file_name);
            $target_file = $target_dir . $new_file_name;

            if (move_uploaded_file($_FILES["cover_image"]["tmp_name"], $target_file)) {
                $cover_image = $target_file; // Store the path
            } else {
                echo "Error uploading file.";
                exit;
            }
        } else {
            echo "Invalid file type or size too large.";
            exit;
        }
    }

    // Insert the album into the database
    $sql = "INSERT INTO Albums (title, artist_id, release_date, genre, cover_image)
            VALUES ('$album_title', $artist_id, '$release_date', '$genre', '$cover_image')";

    if ($conn->query($sql) === true) {
        header("Location: index.php");
        // echo "New album inserted successfully!";
    } else {
        echo "Error: " . $conn->error;
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Insert Album</title>
</head>
<body>
    <h2>Add a New Album</h2>
    <form action="" method="post" enctype="multipart/form-data">
        <label for="album_title">Album Title:</label>
        <input type="text" id="album_title" name="album_title" required><br><br>

        <label for="artist_id">Select Artist:</label>
        <select id="artist_id" name="artist_id" required>
            <?php
            $sql = "SELECT artist_id, name FROM Artists";
            $result = $conn->query($sql);

            if ($result->num_rows > 0) {
                while ($row = $result->fetch_assoc()) {
                    echo "<option value='{$row["artist_id"]}'>{$row["name"]}</option>";
                }
            } else {
                echo "<option>No artists available</option>";
            }
            ?>
        </select><br><br>

        <label for="release_date">Release Date:</label>
        <input type="date" id="release_date" name="release_date" required><br><br>

        <label for="genre">Genre:</label>
        <input type="text" id="genre" name="genre" required><br><br>

        <label for="cover_image">Album Cover:</label>
        <input type="file" id="cover_image" name="cover_image" accept="image/*"><br><br>

        <input type="submit" value="Insert Album">
    </form>
</body>
</html>
