DROP DATABASE IF EXISTS music_db;
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
    file_path VARCHAR(255),
    FOREIGN KEY (artist_id) REFERENCES Artists (artist_id) ON DELETE CASCADE,
    FOREIGN KEY (album_id) REFERENCES Albums (album_id) ON DELETE SET NULL
);

-- Insert data into Artists
INSERT INTO
    Artists (name, country, birth_date, image_path)
VALUES
    ('The Beatles', 'UK', '1960-01-01', 'uploads/the_beetles.jpg'),
    ('Eminem', 'USA', '1972-10-17', 'uploads/eminem.webp'),
    ('Taylor Swift', 'USA', '1989-12-13', 'uploads/taylor_swift.webp'),
    ('Vannda', 'Cambodia', '1997-1-22', 'uploads/vannda.webp')
    ;

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
    ('1989', 3, '2014-10-27', 'Pop'),
    ('TREY VISAI II', 4, '2025-3-21','Hip-Hop' )
    ;

-- Insert data into Songs
INSERT INTO
    Songs (
        title,
        artist_id,
        album_id,
        duration,
        genre,
        release_date,
        file_path
    )
VALUES
    ('Come Together', 1, 1, 259, 'Rock', '1969-09-26', 'uploads/songs/The Beatles - Come Together.mp3'),
    ('Stan', 2, 2, 404, 'Hip-Hop', '2000-05-23', 'uploads/songs/Eminem - Stan (Lyrics) ft. Dido.mp3'),
    ('Shake It Off', 3, 3, 219, 'Pop', '2014-08-18', 'uploads/songs/Taylor Swift - Shake It Off (Taylor''s Version) (Lyric Video).mp3'),
    ('A SONG FOR YOU', 4, 4, 264, 'Hip-Hop', '2025-3-21', 'uploads/songs/VANNDA - A SONG FOR YOU (ចមរងជន Ex Part 3) [OFFICIAL AUDIO].mp3')
    ;
