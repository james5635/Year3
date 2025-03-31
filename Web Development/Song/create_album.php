<?php
require_once "connectDB.php";
global $conn;
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Get form data
    $album_title = $_POST["album_title"];
    $artist_id = $_POST["artist_id"];
    $release_date = $_POST["release_date"];
    $genre = $_POST["genre"];

    // Insert the album
    $sql = "INSERT INTO Albums (title, artist_id, release_date, genre)
        VALUES ('$album_title', $artist_id, '$release_date', '$genre')";

    if ($conn->query($sql) === true) {
        echo "New album inserted successfully!";
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
    <form action="" method="post">
        <label for="album_title">Album Title:</label>
        <input type="text" id="album_title" name="album_title" required><br><br>

        <label for="artist_id">Select Artist:</label>
        <select id="artist_id" name="artist_id" required>
            <!-- Artist options will be dynamically loaded here from the database -->
            <?php
            $sql = "SELECT artist_id, name FROM Artists";
            $result = $conn->query($sql);

            if ($result->num_rows > 0) {
                while ($row = $result->fetch_assoc()) {
                    echo "<option value='" .
                        $row["artist_id"] .
                        "'>" .
                        $row["name"] .
                        "</option>";
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

        <input type="submit" value="Insert Album">
    </form>
</body>
</html>
