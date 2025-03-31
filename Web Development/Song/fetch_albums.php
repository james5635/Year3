<?php
include 'connectDB.php';

if (isset($_GET['artist_id'])) {
    $artist_id = intval($_GET['artist_id']); // Ensure it's an integer

    $sql = "SELECT album_id, title FROM Albums WHERE artist_id = $artist_id ORDER BY title";
    $result = $conn->query($sql);

    $albums = [];
    while ($row = $result->fetch_assoc()) {
        $albums[] = $row;
    }

    echo json_encode($albums);
}

$conn->close();
?>
