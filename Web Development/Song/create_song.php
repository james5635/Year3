<?php
include "connectDB.php";

global $conn;

// Check if form is submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $title = $_POST["title"];
    $artist_id = $_POST["artist_id"];
    $album_id = !empty($_POST["album_id"]) ? $_POST["album_id"] : "NULL"; // Allow NULL
    $duration = $_POST["duration"];
    $genre = $_POST["genre"];
    $release_date = $_POST["release_date"];

    // Handle file upload
    $upload_dir = "uploads/songs/";
    if (!is_dir($upload_dir)) {
        mkdir($upload_dir, 0777, true);
    }

    $file_path = "";
    if (!empty($_FILES["song_file"]["name"])) {
        $file_name = basename($_FILES["song_file"]["name"]);
        $target_file = $upload_dir . $file_name;
        // Check file type
        $file_type = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));
        if (in_array($file_type, ["mp3", "wav"])) {
            file_put_contents(
                "php://stdout",
                print_r("uploading file ({$file_name})....\n", true)
            );
            if (
                move_uploaded_file(
                    $_FILES["song_file"]["tmp_name"],
                    $target_file
                )
            ) {
                $file_path = $target_file;
            } else {
                echo "Error uploading file.";
            }
        } else {
            echo "Invalid file type. Only MP3 and WAV are allowed.";
            exit();
        }
    }

    // Prepare the SQL query
    $sql = "INSERT INTO Songs (title, artist_id, album_id, duration, genre, release_date, file_path)
            VALUES ('$title', $artist_id, $album_id, $duration, '$genre', '$release_date', '$file_path')";

    if ($conn->query($sql) === true) {
        header("Location: index.php");

        // echo "New song inserted successfully!";
    } else {
        echo "Error: " . $conn->error;
    }
    $conn->close();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Insert Song</title>
    <script>
        function fetchAlbums() {
            var artistId = document.getElementById("artist_id").value;
            var albumSelect = document.getElementById("album_id");

            albumSelect.innerHTML = '<option value="">Select Album (Optional)</option>';

            if (artistId) {
                var xhr = new XMLHttpRequest();
                xhr.open("GET", "fetch_albums.php?artist_id=" + artistId, true);
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        var albums = JSON.parse(xhr.responseText);
                        albums.forEach(function(album) {
                            var option = document.createElement("option");
                            option.value = album.album_id;
                            option.textContent = album.title;
                            albumSelect.appendChild(option);
                        });
                    }
                };
                xhr.send();
            }
        }
    </script>
</head>
<body>
    <h2>Insert New Song</h2>
    <form action="" method="post" enctype="multipart/form-data">
        <label for="title">Song Title:</label>
        <input type="text" name="title" required>
        <br><br>

        <label for="artist_id">Artist:</label>
        <select name="artist_id" id="artist_id" onchange="fetchAlbums()" required>
            <option value="">Select Artist</option>
            <?php
            include "connectDB.php";
            $result = $conn->query(
                "SELECT artist_id, name FROM Artists ORDER BY name"
            );
            while ($row = $result->fetch_assoc()) {
                echo "<option value='{$row["artist_id"]}'>{$row["name"]}</option>";
            }
            ?>
        </select>
        <br><br>

        <label for="album_id">Album:</label>
        <select name="album_id" id="album_id">
            <option value="">Select Album (Optional)</option>
        </select>
        <br><br>

        <label for="duration">Duration (seconds):</label>
        <input type="number" name="duration" required min="1">
        <br><br>

        <label for="genre">Genre:</label>
        <input type="text" name="genre">
        <br><br>

        <label for="release_date">Release Date:</label>
        <input type="date" name="release_date">
        <br><br>

        <label for="song_file">Upload Song:</label>
        <input type="file" name="song_file" accept="audio/mp3, audio/wav">
        <br><br>

        <input type="submit" value="Insert Song">
    </form>
</body>
</html>
