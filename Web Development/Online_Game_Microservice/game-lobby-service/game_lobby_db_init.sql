CREATE TABLE IF NOT EXISTS lobbies (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    max_players INT NOT NULL,
    current_players INT DEFAULT 0,
    status VARCHAR(50) DEFAULT 'waiting',
    created_by_user_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS lobby_players (
    lobby_id INT NOT NULL,
    user_id INT NOT NULL,
    joined_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (lobby_id, user_id),
    FOREIGN KEY (lobby_id) REFERENCES lobbies(id) ON DELETE CASCADE
);