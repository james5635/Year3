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
        .add-song:hover {
            background-color: #0056b3;
        }

        .artist-header {
            display: flex;
            align-items: center;
            justify-content: space-between; /* Adjust as needed */
           // gap: 0px; /* Adds spacing */
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


        .album-header {
            display: flex;
            align-items: center;
            justify-content: space-between; /* Adjust as needed */
           // gap: 0px; /* Adds spacing */
        }

        .add-album {
            text-decoration: none;
            background-color: #007bff;
            color: white;
            padding: 8px 12px;
            border-radius: 5px;
            font-size: 14px;
        }

        .add-album:hover {
            background-color: #0056b3;
        }





        #artist-img {
            width: 50px;
            height: 50px;
            object-fit: cover;
            border-radius: 50%;
        }


        /* Modal styles */
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.7);
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .modal-content {
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            position: relative;
            text-align: center;
            max-width: 80%;
            max-height: 80%;
        }
        .modal img {
            max-width: 100%;
            max-height: 70vh;
            border-radius: 10px;
        }
        .close {
            position: absolute;
            top: 10px;
            right: 15px;
            font-size: 25px;
            font-weight: bold;
            cursor: pointer;
            color: #333;
        }
        .close:hover {
            color: red;
        }
        .view-image-btn {
            background: linear-gradient(135deg, #007bff, #0056b3); /* Blue gradient */
            color: white;
            border: none;
            padding: 8px 12px;
            border-radius: 8px;
            cursor: pointer;
            font-size: 14px;
            transition: 0.3s ease-in-out;
        }

        .view-image-btn:hover {
            background: linear-gradient(135deg, #0056b3, #003d80);
            transform: scale(1.05);
        }

    </style>

    <style>
        .artist-thumbnail {
            width: 50px;
            height: 50px;
            object-fit: cover;
            border-radius: 50%;
            cursor: pointer;
            transition: transform 0.2s ease-in-out;
        }

        .artist-thumbnail:hover {
            transform: scale(1.1);
        }

        .artist-modal {
            display: none;
            position: fixed;
            z-index: 1000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.7);
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .artist-modal-content {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            position: relative;
            text-align: center;
            max-width: 80%;
            max-height: 80%;
        }

        .artist-modal img {
            max-width: 100%;
            max-height: 70vh;
            border-radius: 10px;
        }

        .artist-close {
            position: absolute;
            top: 10px;
            right: 15px;
            font-size: 25px;
            font-weight: bold;
            cursor: pointer;
            color: #333;
        }

        .artist-close:hover {
            color: red;
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
                            <td><audio controls><source src=\"{$row["file_path"]}\" type='audio/mpeg'>
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
        <a href="/create_artist.php" class="add-artist">Add Artist</a>
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
                    <td>" .
                        ($row["birth_date"] ?? "N/A") .
                        "</td>
                            <td>
                                <img class='artist-thumbnail' src='{$row["image_path"]}' alt='Artist Image' onclick='openArtistModal(\"{$row["image_path"]}\")'>
                            </td>
                          </tr>";
                    $count++;
                }
            } else {
                echo "<tr><td colspan='5'>No artists found</td></tr>";
            }
            ?>
        </tbody>
    </table>

    <!-- Artist Modal -->
    <div id="artistModal" class="artist-modal">
        <div class="artist-modal-content">
            <span class="artist-close" onclick="closeArtistModal()">&times;</span>
            <img id="artistModalImage" src="" alt="Artist Image">
        </div>
    </div>

    <div class="album-header">
        <h2>Album List</h2>
        <a href="/create_album.php" class="add-album">Add Album</a>
    </div>

    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Album Title</th>
                <th>Artist</th>
                <th>Release Date</th>
                <th>Genre</th>
                <th>Album Image</th>
            </tr>
        </thead>
        <tbody>
            <?php
            $sql = "SELECT
                        Albums.album_id,
                        Albums.title AS album_title,
                        Artists.name AS artist_name,
                        Albums.release_date,
                        Albums.genre,
                        Albums.cover_image
                    FROM Albums
                    JOIN Artists ON Albums.artist_id = Artists.artist_id
                    ORDER BY Albums.title";

            $result = $conn->query($sql);

            if ($result->num_rows > 0) {
                $count = 1;
                while ($row = $result->fetch_assoc()) {
                    $image = !empty($row["cover_image"])
                        ? $row["cover_image"]
                        : "default-cover.jpg";
                    echo "<tr>
                            <td>{$count}</td>
                            <td>{$row["album_title"]}</td>
                            <td>{$row["artist_name"]}</td>
                            <td>{$row["release_date"]}</td>
                            <td>{$row["genre"]}</td>
                            <td class='album-cover'>
                                <button class='view-image-btn' onclick='openModal(\"{$image}\")'>View Image</button>
                            </td>
                          </tr>";
                    $count++;
                }
            } else {
                echo "<tr><td colspan='6'>No albums found</td></tr>";
            }
            $conn->close();
            ?>
        </tbody>
    </table>

    <!-- Modal -->
    <div id="albumModal"  class="modal">
        <div class="modal-content">
            <span class="close" onclick="closeModal()">&times;</span>
            <img id="modalImage" src="" alt="Album Image">
        </div>
    </div>

    <script>
        var modal = document.getElementById("albumModal");
        var modalImage = document.getElementById("modalImage");
        var artist_modal = document.getElementById("artistModal");

        modal.style.display = "none";
        artist_modal.style.display = "none";

        function openModal(imageUrl) {
            modalImage.src = imageUrl;
            modal.style.display = "flex";
        }

        function closeModal() {
            modal.style.display = "none";
        }

        function openArtistModal(imageUrl) {
             document.getElementById("artistModalImage").src = imageUrl;
             document.getElementById("artistModal").style.display = "flex";
         }

         function closeArtistModal() {
             document.getElementById("artistModal").style.display = "none";
         }

        // Close modal when clicking outside of the image
        window.onclick = function(event) {
            if (event.target === modal) {
                closeModal();
            }
               if (event.target === artist_modal) {
                   closeArtistModal();
               }
        };
    </script>
</body>
</html>
