<?php
include 'connectDB.php';

if (isset($_GET['song_id'])) {
    $song_id = intval($_GET['song_id']);

    // Delete song
    $sql = "DELETE FROM Songs WHERE song_id = $song_id";

    if ($conn->query($sql) === TRUE) {
        echo "Song deleted successfully!";
    } else {
        echo "Error deleting song: " . $conn->error;
    }

    $conn->close();
    header("Location: index.php"); // Redirect back
    exit();
}
?>
