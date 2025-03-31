<?php
include 'connectDB.php';

// Fetch song details
if (isset($_GET['song_id'])) {
    $song_id = intval($_GET['song_id']);
    $sql = "SELECT * FROM Songs WHERE song_id = $song_id";
    $result = $conn->query($sql);
    $song = $result->fetch_assoc();
}

// Handle update request
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $song_id = intval($_POST['song_id']);
    $title = $_POST['title'];
    $artist_id = $_POST['artist_id'];
    $album_id = $_POST['album_id'] ?: "NULL"; // Handle optional album
    $duration = $_POST['duration'];
    $genre = $_POST['genre'];
    $release_date = $_POST['release_date'];

    $sql = "UPDATE Songs 
            SET title = '$title', artist_id = $artist_id, album_id = $album_id, 
                duration = $duration, genre = '$genre', release_date = '$release_date' 
            WHERE song_id = $song_id";

    if ($conn->query($sql) === TRUE) {
        echo "Song updated successfully!";
        header("Location: index.php"); // Redirect back
        exit();
    } else {
        echo "Error updating song: " . $conn->error;
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Update Song</title>
</head>
<body>
    <h2>Update Song</h2>
    <form action="update_song.php" method="post">
        <input type="hidden" name="song_id" value="<?php echo $song['song_id']; ?>">

        <label for="title">Song Title:</label>
        <input type="text" name="title" value="<?php echo $song['title']; ?>" required>
        <br><br>

        <label for="artist_id">Artist:</label>
        <select name="artist_id" required>
            <?php
            $result = $conn->query("SELECT artist_id, name FROM Artists ORDER BY name");
            while ($row = $result->fetch_assoc()) {
                $selected = ($row['artist_id'] == $song['artist_id']) ? "selected" : "";
                echo "<option value='{$row['artist_id']}' $selected>{$row['name']}</option>";
            }
            ?>
        </select>
        <br><br>

        <label for="album_id">Album:</label>
        <select name="album_id">
            <option value="">No Album</option>
            <?php
            $result = $conn->query("SELECT album_id, title FROM Albums ORDER BY title");
            while ($row = $result->fetch_assoc()) {
                $selected = ($row['album_id'] == $song['album_id']) ? "selected" : "";
                echo "<option value='{$row['album_id']}' $selected>{$row['title']}</option>";
            }
            ?>
        </select>
        <br><br>

        <label for="duration">Duration (seconds):</label>
        <input type="number" name="duration" value="<?php echo $song['duration']; ?>" required min="1">
        <br><br>

        <label for="genre">Genre:</label>
        <input type="text" name="genre" value="<?php echo $song['genre']; ?>">
        <br><br>

        <label for="release_date">Release Date:</label>
        <input type="date" name="release_date" value="<?php echo $song['release_date']; ?>">
        <br><br>

        <input type="submit" value="Update Song">
    </form>
</body>
</html>
