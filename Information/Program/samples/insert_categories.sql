INSERT INTO product_categories (screen_id, name_key)
VALUES
((SELECT id FROM screens WHERE name = 'Bar'), 'CategoryName-coffee'),
((SELECT id FROM screens WHERE name = 'Kitchen'), 'CategoryName-snacks'),
((SELECT id FROM screens WHERE name = 'Bar'), 'CategoryName-beer');

INSERT INTO language (key, language, value) VALUES
('CategoryName-coffee', 0, 'Koffie'),
('CategoryName-coffee', 1, 'Coffee'),

('CategoryName-snacks', 0, 'Snacks'),
('CategoryName-snacks', 1, 'Snacks'),

('CategoryName-beer', 0, 'Bier'),
('CategoryName-beer', 1, 'Beer');