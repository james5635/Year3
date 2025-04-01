<?php
include "connectDB.php";
global $conn;
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
   
        .song-header {
            display: flex;
            align-items: center;
            justify-content: space-between; /* Adjust as needed */
           // gap: 0px; /* Adds spacing */
        }
    
        .add-song {
            text-decoration: none;
            background-color: #007bff;
            color: white;
            padding: 8px 12px;
            border-radius: 5px;
            font-size: 14px;
        }
        .artist-header {
            display: flex;
            align-items: center;
            justify-content: space-between; /* Adjust as needed */
           // gap: 0px; /* Adds spacing */
        }
        .add-song:hover {
            background-color: #0056b3;
        }
        .add-artist {
            text-decoration: none;
            background-color: #007bff;
            color: white;
            padding: 8px 12px;
            border-radius: 5px;
            font-size: 14px;
        }
    
        .add-artist:hover {
            background-color: #0056b3;
        }
        
        img {
            width: 50px;
            height: 50px;
            object-fit: cover;
            border-radius: 50%;
        }
    </style>
</head>
<body>
    <div class="song-header">
        <h2>Song List</h2>
        <a href="/create_song.php" class="add-song">Add Song</a>
    </div>
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
                <th>Play</th>
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
                             Songs.release_date,
                             Songs.file_path
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
                            <td>{$row["song_title"]}</td>
                            <td>{$row["artist_name"]}</td>
                            <td>" .
                        ($row["album_title"] ?? "N/A") .
                        "</td>
                            <td>{$row["duration"]}</td>
                            <td>{$row["genre"]}</td>
                            <td>{$row["release_date"]}</td>
                            <td><audio controls><source src=\"{$row['file_path']}\" type='audio/mpeg'>
                             Your browser does not support the audio tag.
                            </audio></td>
                            <td class='action-buttons'>
                                <a href='update_song.php?song_id={$row["song_id"]}' class='edit-btn'>Edit</a>
                                <a href='delete_song.php?song_id={$row["song_id"]}' class='delete-btn' onclick='return confirm(\"Are you sure you want to delete this song?\")'>Delete</a>
                            </td>
                          </tr>";
                    $count++;
                }
            } else {
                echo "<tr><td colspan='8'>No songs found</td></tr>";
            }
            ?>
        </tbody>
    </table>
    <div class="artist-header">
        <h2>Artists List</h2>
        <a href="/create_artist.php" class="add-artist">Add Song</a>
    </div>
    
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Artist Name</th>
                <th>Country</th>
                <th>Birth Date</th>
                <th>Image</th>
            </tr>
        </thead>
        <tbody>
            <?php
            $sql = "SELECT * FROM Artists ORDER BY name";
            $result = $conn->query($sql);
            if ($result->num_rows > 0) {
                $count = 1;
                while ($row = $result->fetch_assoc()) {
                    echo "<tr>
                            <td>{$count}</td>
                            <td>{$row["name"]}</td>
                            <td>{$row["country"]}</td>
                            <td>{$row["birth_date"]}</td>
                            <td><img src='{$row["image_path"]}' alt='Artist Image'></td>
                          </tr>";
                    $count++;
                }
            } else {
                echo "<tr><td colspan='5'>No artists found</td></tr>";
            }
            $conn->close();
            ?>
        </tbody>
    </table>
</body>
</html>
