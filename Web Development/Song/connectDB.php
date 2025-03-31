<?php
mysqli_report(MYSQLI_REPORT_OFF);

$servername = "localhost";
$username = "jame"; // Adjust as needed
$password = "jame"; // Adjust as needed
$dbname = "music_db"; // Adjust as needed
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    error_log("Connection error: " . $conn->connect_error);
    die("error");
}

?>
