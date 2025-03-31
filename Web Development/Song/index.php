<?php
include 'connectDB.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Song List</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid black;
            padding: 10px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
        }
        .action-buttons a {
            margin-right: 10px;
            text-decoration: none;
            padding: 5px 10px;
            border-radius: 5px;
        }
        .edit-btn {
            background-color: #ffc107;
            color: black;
        }
        .delete-btn {
            background-color: #dc3545;
            color: white;
        }
    </style>
</head>
<body>
    <h2>Song List</h2>
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Song Title</th>
                <th>Artist</th>
                <th>Album</th>
                <th>Duration (s)</th>
                <th>Genre</th>
                <th>Release Date</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <?php
            $sql = "SELECT 
                        Songs.song_id, 
                        Songs.title AS song_title, 
                        Artists.name AS artist_name, 
                        Albums.title AS album_title, 
                        Songs.duration, 
                        Songs.genre, 
                        Songs.release_date
                    FROM Songs
                    JOIN Artists ON Songs.artist_id = Artists.artist_id
                    LEFT JOIN Albums ON Songs.album_id = Albums.album_id
                    ORDER BY Songs.title";

            $result = $conn->query($sql);
            if ($result->num_rows > 0) {
                $count = 1;
                while ($row = $result->fetch_assoc()) {
                    echo "<tr>
                            <td>{$count}</td>
                            <td>{$row['song_title']}</td>
                            <td>{$row['artist_name']}</td>
                            <td>" . ($row['album_title'] ?? 'N/A') . "</td>
                            <td>{$row['duration']}</td>
                            <td>{$row['genre']}</td>
                            <td>{$row['release_date']}</td>
                            <td class='action-buttons'>
                                <a href='update_song.php?song_id={$row['song_id']}' class='edit-btn'>Edit</a>
                                <a href='delete_song.php?song_id={$row['song_id']}' class='delete-btn' onclick='return confirm(\"Are you sure you want to delete this song?\")'>Delete</a>
                            </td>
                          </tr>";
                    $count++;
                }
            } else {
                echo "<tr><td colspan='8'>No songs found</td></tr>";
            }
            $conn->close();
            ?>
        </tbody>
    </table>
</body>
</html>
