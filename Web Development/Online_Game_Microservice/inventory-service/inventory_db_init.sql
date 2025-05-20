CREATE TABLE IF NOT EXISTS items (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL UNIQUE,
    description TEXT,
    type VARCHAR(100),
    rarity VARCHAR(50),
    value INT DEFAULT 0
);

CREATE TABLE IF NOT EXISTS user_inventory (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    item_id INT NOT NULL,
    quantity INT DEFAULT 1,
    acquired_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (item_id) REFERENCES items(id) ON DELETE CASCADE,
    UNIQUE KEY (user_id, item_id)
);

INSERT IGNORE INTO items (id, name, description, type, rarity, value) VALUES
(1, 'Basic Sword', 'A simple sword.', 'weapon', 'common', 10),
(2, 'Health Potion', 'Restores a small amount of health.', 'consumable', 'common', 5),
(3, 'Dragon Armor', 'Legendary armor crafted from dragon scales.', 'armor', 'epic', 1000);