<?php
include "connectDB.php";
global $conn;
if (isset($_GET["song_id"])) {
    $song_id = intval($_GET["song_id"]);

    // Delete song
    // $sql = "DELETE FROM Songs WHERE song_id = $song_id";
    // Update isActive to 0
    $sql = "UPDATE Songs SET isActive = 0 WHERE song_id = $song_id;
";
    if ($conn->query($sql) === true) {
        echo "Song deleted successfully!";
    } else {
        echo "Error deleting song: " . $conn->error;
    }

    $conn->close();
    header("Location: index.php"); // Redirect back
    exit();
}
?>
