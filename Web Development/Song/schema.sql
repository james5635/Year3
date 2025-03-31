CREATE DATABASE music_db;
GRANT ALL PRIVILEGES ON song_db.* TO 'jame'@'localhost';
USE music_db;
-- Artists Table
CREATE TABLE Artists (
    artist_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    country VARCHAR(50),
    birth_date DATE,
    image_path VARCHAR(255)
);

-- Albums Table
CREATE TABLE Albums (
    album_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    artist_id INT,
    release_date DATE,
    genre VARCHAR(50),
    FOREIGN KEY (artist_id) REFERENCES Artists (artist_id) ON DELETE CASCADE
);

-- Songs Table
CREATE TABLE Songs (
    song_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    artist_id INT,
    album_id INT,
    duration INT CHECK (duration > 0), -- Ensure duration is positive
    genre VARCHAR(50),
    release_date DATE,
    FOREIGN KEY (artist_id) REFERENCES Artists (artist_id) ON DELETE CASCADE,
    FOREIGN KEY (album_id) REFERENCES Albums (album_id) ON DELETE SET NULL
);

-- Insert data into Artists
INSERT INTO
    Artists (name, country, birth_date)
VALUES
    ('The Beatles', 'UK', '1960-01-01'),
    ('Eminem', 'USA', '1972-10-17'),
    ('Taylor Swift', 'USA', '1989-12-13');

-- Insert data into Albums
INSERT INTO
    Albums (title, artist_id, release_date, genre)
VALUES
    ('Abbey Road', 1, '1969-09-26', 'Rock'),
    (
        'The Marshall Mathers LP',
        2,
        '2000-05-23',
        'Hip-Hop'
    ),
    ('1989', 3, '2014-10-27', 'Pop');

-- Insert data into Songs
INSERT INTO
    Songs (
        title,
        artist_id,
        album_id,
        duration,
        genre,
        release_date
    )
VALUES
    ('Come Together', 1, 1, 259, 'Rock', '1969-09-26'),
    ('Stan', 2, 2, 404, 'Hip-Hop', '2000-05-23'),
    ('Shake It Off', 3, 3, 219, 'Pop', '2014-08-18');
