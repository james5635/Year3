<?php
include 'connectDB.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Artists List</title>
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
        img {
            width: 50px;
            height: 50px;
            object-fit: cover;
            border-radius: 50%;
        }
    </style>
</head>
<body>
    <h2>Artists List</h2>
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
                            <td>{$row['name']}</td>
                            <td>{$row['country']}</td>
                            <td>{$row['birth_date']}</td>
                            <td><img src='{$row['image_path']}' alt='Artist Image'></td>
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
