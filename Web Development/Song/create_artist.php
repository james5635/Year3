<?php
include 'connectDB.php';

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $name = $_POST['name'];
    $country = $_POST['country'];
    $birth_date = $_POST['birth_date'];
    $image_path = null;

    // Handle file upload
    if (isset($_FILES['artist_image']) && $_FILES['artist_image']['error'] == 0) {
        $target_dir = "uploads/";
        $image_path = $target_dir . basename($_FILES["artist_image"]["name"]);
        
        // Move uploaded file
        file_put_contents('php://stdout', print_r("uploading file ....\n", TRUE));
        if (!move_uploaded_file($_FILES["artist_image"]["tmp_name"], $image_path)) {
            echo "Error uploading image.";
            exit();
        }
    }

    // Insert artist with image path
    $sql = "INSERT INTO Artists (name, country, birth_date, image_path) 
            VALUES ('$name', '$country', '$birth_date', '$image_path')";

    if ($conn->query($sql) === TRUE) {
        echo "Artist added successfully!";
    } else {
        echo "Error: " . $conn->error;
    }

    $conn->close();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Artist</title>
</head>
<body>
    <h2>Add Artist</h2>
    <form action="" method="post" enctype="multipart/form-data">
        <label for="name">Artist Name:</label>
        <input type="text" name="name" required><br><br>

        <label for="country">Country:</label>
        <input type="text" name="country"><br><br>

        <label for="birth_date">Birth Date:</label>
        <input type="date" name="birth_date"><br><br>

        <label for="artist_image">Artist Image:</label>
        <input type="file" name="artist_image" accept="image/*"><br><br>

        <input type="submit" value="Add Artist">
    </form>
</body>
</html>
