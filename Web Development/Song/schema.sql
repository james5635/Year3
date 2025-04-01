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
    cover_image VARCHAR(255),
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
    isActive TINYINT(1) DEFAULT 1,
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
    ('Vannda (វណ្ណដា)', 'Cambodia', '1997-1-22', 'uploads/vannda.webp'),

    ('Davit (ដាវីត)', 'Cambodia',NULL,'uploads/davit_composer.jpg'),
    ('Tena (ថេណា)', 'Cambodia','1993-10-20','uploads/tena.jpg'),
    ('Fujii Kaze (藤井 風)', 'Japan','1997-6-14','uploads/Fujii-Kaze-1.jpg')



    ;

-- Insert data into Albums
INSERT INTO
    Albums (title, artist_id, release_date, genre, cover_image)
VALUES
    ('Abbey Road', 1, '1969-09-26', 'Rock', 'uploads/albums/Beatles_-_Abbey_Road.jpg'),
    (
        'The Marshall Mathers LP',
        2,
        '2000-05-23',
        'Hip-Hop',
        'uploads/albums/The_Marshall_Mathers_LP.jpg'
    ),
    ('1989', 3, '2014-10-27', 'Pop', 'uploads/albums/Album_Spotlight_Taylor_Swift_1989_Taylor_s_Version.png'),
    ('TREY VISAI II', 4, '2025-3-21','Hip-Hop', 'uploads/albums/treyvisaiii.jpg' )
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
    ('A SONG FOR YOU', 4, 4, 264, 'Pop', '2025-3-21', 'uploads/songs/VANNDA - A SONG FOR YOU (ចមរងជន Ex Part 3) [OFFICIAL AUDIO].mp3'),
    ('ជាប់រវល់', 5, NULL, 255, 'Pop', '2025-3-29', 'uploads/songs/Davit  ជបរវល [ Live Band cover ].mp3'),
    ('សង្រ្កាន្តស្គាល់ស្នេហ៍', 4,NULL, 292, 'Pop', '2024-4-5', 'uploads/songs/VANNDA - សង្រ្កាន្តស្គាល់ស្នេហ៍ (SANGKRAN MAGIC) [OFFICIAL MUSIC VIDEO] [Cpo3DmbdCxs].mp3'),
    ('អាមុំបងអើយ', 4,NULL, 255, 'Pop', '2024-11-12', 'uploads/songs/VANNDA - អាមុំបងអើយ (BAD LIL BOO) [OFFICIAL MUSIC VIDEO] [dXITrblyQCs].mp3'),
    ('មានអារម្មណ៍', 6,NULL, 298, 'Pop', '2024-11-22', 'uploads/songs/Mean Ah Rom.mp3'),
     ('Matsuri', 7,NULL, 249, 'Pop', '2022-3-20', 'uploads/songs/Fujii Kaze -  Matsuri.mp3')
    ;
