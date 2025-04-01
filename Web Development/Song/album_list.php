<?php
include "connectDB.php";
global $conn;
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Album List</title>
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
        .album-cover {
            text-align: center;
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
</head>
<body>
    <h2>Album List</h2>
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
    <div id="albumModal" style="display:none" class="modal">
        <div class="modal-content">
            <span class="close" onclick="closeModal()">&times;</span>
            <img id="modalImage" src="" alt="Album Image">
        </div>
    </div>

    <script>
        var modal = document.getElementById("albumModal");
        var modalImage = document.getElementById("modalImage");
        // modal.style.display = "none";

        function openModal(imageUrl) {
            modalImage.src = imageUrl;
            modal.style.display = "flex";
        }

        function closeModal() {
            modal.style.display = "none";
        }

        // Close modal when clicking outside of the image
        window.onclick = function(event) {
            if (event.target === modal) {
                closeModal();
            }
        };
    </script>
</body>
</html>
