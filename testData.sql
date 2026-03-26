BEGIN;

INSERT INTO users(id, display_name, is_admin) VALUES (1, 'Mr delux', true);

INSERT INTO product_categories (screen_id, name_key)
VALUES
((SELECT id FROM screens WHERE name = 'Bar'), 'CategoryName-coffee'),
((SELECT id FROM screens WHERE name = 'Kitchen'), 'CategoryName-snacks'),
((SELECT id FROM screens WHERE name = 'Bar'), 'CategoryName-beer');

INSERT INTO language (key, language, value)
VALUES
('CategoryName-coffee', 0, 'Koffie'), ('CategoryName-coffee', 1, 'Coffee'),
('CategoryName-snacks', 0, 'Snacks'), ('CategoryName-snacks', 1, 'Snacks'),
('CategoryName-beer', 0, 'Bier'), ('CategoryName-beer', 1, 'Beer');


-- =========================================================
-- COFFEE CATEGORY PRODUCTS (10)
-- =========================================================

INSERT INTO products (title_key, description_key, price_cent, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-coffee-1', 'ProductDescription-coffee-1', 2.50, 21, 100, true, '/images/coffee-espresso.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-2', 'ProductDescription-coffee-2', 3.00, 21, 100, true, '/images/coffee-latte.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-3', 'ProductDescription-coffee-3', 3.20, 21, 100, true, '/images/coffee-cappuccino.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-4', 'ProductDescription-coffee-4', 2.80, 21, 100, true, '/images/coffee-americano.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-5', 'ProductDescription-coffee-5', 3.50, 21, 100, true, '/images/coffee-mocha.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-6', 'ProductDescription-coffee-6', 3.00, 21, 100, true, '/images/coffee-flatwhite.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-7', 'ProductDescription-coffee-7', 2.70, 21, 100, true, '/images/coffee-ristretto.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-8', 'ProductDescription-coffee-8', 3.30, 21, 100, true, '/images/coffee-macchiato.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-9', 'ProductDescription-coffee-9', 3.80, 21, 100, true, '/images/coffee-iced.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee')),
('ProductTitle-coffee-10', 'ProductDescription-coffee-10', 4.00, 21, 100, true, '/images/coffee-special.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-coffee'));

-- =========================================================
-- SNACKS CATEGORY PRODUCTS (10)
-- =========================================================

INSERT INTO products (title_key, description_key, price_cent, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-snacks-1', 'ProductDescription-snacks-1', 4.50, 21, 100, true, '/images/snack-fries.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-2', 'ProductDescription-snacks-2', 5.50, 21, 100, true, '/images/snack-bitterballen.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-3', 'ProductDescription-snacks-3', 6.00, 21, 100, true, '/images/snack-nachos.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-4', 'ProductDescription-snacks-4', 7.50, 21, 100, true, '/images/snack-burger.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-5', 'ProductDescription-snacks-5', 5.00, 21, 100, true, '/images/snack-sandwich.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-6', 'ProductDescription-snacks-6', 6.50, 21, 100, true, '/images/snack-wrap.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-7', 'ProductDescription-snacks-7', 8.00, 21, 100, true, '/images/snack-pizza.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-8', 'ProductDescription-snacks-8', 4.00, 21, 100, true, '/images/snack-salad.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-9', 'ProductDescription-snacks-9', 5.75, 21, 100, true, '/images/snack-cheese.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks')),
('ProductTitle-snacks-10', 'ProductDescription-snacks-10', 6.25, 21, 100, true, '/images/snack-mix.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-snacks'));


BEGIN;

-- =========================================================
-- BEER CATEGORY PRODUCTS (10)
-- =========================================================

INSERT INTO products (title_key, description_key, price_cent, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-beer-1', 'ProductDescription-beer-1', 3.50, 21, 100, true, '/images/beer-bolleke.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-2', 'ProductDescription-beer-2', 4.50, 21, 100, true, '/images/beer-tripel.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-3', 'ProductDescription-beer-3', 4.00, 21, 100, true, '/images/beer-blond.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-4', 'ProductDescription-beer-4', 4.20, 21, 100, true, '/images/beer-amber.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-5', 'ProductDescription-beer-5', 4.80, 21, 100, true, '/images/beer-mira.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-6', 'ProductDescription-beer-6', 5.00, 21, 100, true, '/images/beer-duvel.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-7', 'ProductDescription-beer-7', 4.30, 21, 100, true, '/images/beer-hoegaarden.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-8', 'ProductDescription-beer-8', 4.60, 21, 100, true, '/images/beer-leffe.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-9', 'ProductDescription-beer-9', 3.80, 21, 100, true, '/images/beer-stella.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer')),
('ProductTitle-beer-10', 'ProductDescription-beer-10', 5.20, 21, 100, true, '/images/beer-westmalle.jpg', (SELECT id FROM product_categories WHERE name_key = 'CategoryName-beer'));


-- =========================================================
-- LANGUAGE ENTRIES (TRANSLATIONS)
-- =========================================================

INSERT INTO language (key, language, value) VALUES

-- Coffee titles + descriptions
('ProductTitle-coffee-1', 0, 'Espresso'), ('ProductTitle-coffee-1', 1, 'Espresso'),
('ProductDescription-coffee-1', 0, 'Sterke koffie shot'), ('ProductDescription-coffee-1', 1, 'Strong coffee shot'),

('ProductTitle-coffee-2', 0, 'Latte'), ('ProductTitle-coffee-2', 1, 'Latte'),
('ProductDescription-coffee-2', 0, 'Koffie met melk'), ('ProductDescription-coffee-2', 1, 'Coffee with milk'),

('ProductTitle-coffee-3', 0, 'Cappuccino'), ('ProductTitle-coffee-3', 1, 'Cappuccino'),
('ProductDescription-coffee-3', 0, 'Espresso met schuim'), ('ProductDescription-coffee-3', 1, 'Espresso with foam'),

('ProductTitle-coffee-4', 0, 'Americano'), ('ProductTitle-coffee-4', 1, 'Americano'),
('ProductDescription-coffee-4', 0, 'Verdunning van espresso'), ('ProductDescription-coffee-4', 1, 'Diluted espresso'),

('ProductTitle-coffee-5', 0, 'Mocha'), ('ProductTitle-coffee-5', 1, 'Mocha'),
('ProductDescription-coffee-5', 0, 'Koffie met chocolade'), ('ProductDescription-coffee-5', 1, 'Coffee with chocolate'),

('ProductTitle-coffee-6', 0, 'Flat White'), ('ProductTitle-coffee-6', 1, 'Flat White'),
('ProductDescription-coffee-6', 0, 'Sterke melk koffie'), ('ProductDescription-coffee-6', 1, 'Strong milk coffee'),

('ProductTitle-coffee-7', 0, 'Ristretto'), ('ProductTitle-coffee-7', 1, 'Ristretto'),
('ProductDescription-coffee-7', 0, 'Korte espresso'), ('ProductDescription-coffee-7', 1, 'Short espresso'),

('ProductTitle-coffee-8', 0, 'Macchiato'), ('ProductTitle-coffee-8', 1, 'Macchiato'),
('ProductDescription-coffee-8', 0, 'Espresso met melk schuim'), ('ProductDescription-coffee-8', 1, 'Espresso with milk foam'),

('ProductTitle-coffee-9', 0, 'Iced Coffee'), ('ProductTitle-coffee-9', 1, 'Iced Coffee'),
('ProductDescription-coffee-9', 0, 'Koude koffie'), ('ProductDescription-coffee-9', 1, 'Cold coffee'),

('ProductTitle-coffee-10', 0, 'Special Coffee'), ('ProductTitle-coffee-10', 1, 'Special Coffee'),
('ProductDescription-coffee-10', 0, 'Huis specialiteit'), ('ProductDescription-coffee-10', 1, 'House specialty'),

-- Snacks titles + descriptions
('ProductTitle-snacks-1', 0, 'Frieten'), ('ProductTitle-snacks-1', 1, 'Fries'),
('ProductDescription-snacks-1', 0, 'Knapperige frieten'), ('ProductDescription-snacks-1', 1, 'Crispy fries'),

('ProductTitle-snacks-2', 0, 'Bitterballen'), ('ProductTitle-snacks-2', 1, 'Bitterballen'),
('ProductDescription-snacks-2', 0, 'Gefrituurde snacks'), ('ProductDescription-snacks-2', 1, 'Fried snacks'),

('ProductTitle-snacks-3', 0, 'Nachos'), ('ProductTitle-snacks-3', 1, 'Nachos'),
('ProductDescription-snacks-3', 0, 'Met kaas en saus'), ('ProductDescription-snacks-3', 1, 'With cheese and sauce'),

('ProductTitle-snacks-4', 0, 'Burger'), ('ProductTitle-snacks-4', 1, 'Burger'),
('ProductDescription-snacks-4', 0, 'Rundvlees burger'), ('ProductDescription-snacks-4', 1, 'Beef burger'),

('ProductTitle-snacks-5', 0, 'Sandwich'), ('ProductTitle-snacks-5', 1, 'Sandwich'),
('ProductDescription-snacks-5', 0, 'Belegde sandwich'), ('ProductDescription-snacks-5', 1, 'Filled sandwich'),

('ProductTitle-snacks-6', 0, 'Wrap'), ('ProductTitle-snacks-6', 1, 'Wrap'),
('ProductDescription-snacks-6', 0, 'Wrap met vulling'), ('ProductDescription-snacks-6', 1, 'Filled wrap'),

('ProductTitle-snacks-7', 0, 'Pizza'), ('ProductTitle-snacks-7', 1, 'Pizza'),
('ProductDescription-snacks-7', 0, 'Italiaanse pizza'), ('ProductDescription-snacks-7', 1, 'Italian pizza'),

('ProductTitle-snacks-8', 0, 'Salade'), ('ProductTitle-snacks-8', 1, 'Salad'),
('ProductDescription-snacks-8', 0, 'Verse salade'), ('ProductDescription-snacks-8', 1, 'Fresh salad'),

('ProductTitle-snacks-9', 0, 'Kaasplank'), ('ProductTitle-snacks-9', 1, 'Cheese plate'),
('ProductDescription-snacks-9', 0, 'Selectie van kazen'), ('ProductDescription-snacks-9', 1, 'Selection of cheeses'),

('ProductTitle-snacks-10', 0, 'Snack Mix'), ('ProductTitle-snacks-10', 1, 'Snack Mix'),
('ProductDescription-snacks-10', 0, 'Gemengde snacks'), ('ProductDescription-snacks-10', 1, 'Mixed snacks'),

-- Beer titles + descriptions
('ProductTitle-beer-1', 0, 'Bolleke De Koninck'), ('ProductTitle-beer-1', 1, 'Bolleke De Koninck'),
('ProductDescription-beer-1', 0, 'Klassiek amber bier'), ('ProductDescription-beer-1', 1, 'Classic amber beer'),

('ProductTitle-beer-2', 0, 'Tripel Koninck'), ('ProductTitle-beer-2', 1, 'Tripel Koninck'),
('ProductDescription-beer-2', 0, 'Krachtige tripel'), ('ProductDescription-beer-2', 1, 'Strong tripel'),

('ProductTitle-beer-3', 0, 'Blond Bier'), ('ProductTitle-beer-3', 1, 'Blond Beer'),
('ProductDescription-beer-3', 0, 'Licht en fris'), ('ProductDescription-beer-3', 1, 'Light and fresh'),

('ProductTitle-beer-4', 0, 'Amber Bier'), ('ProductTitle-beer-4', 1, 'Amber Beer'),
('ProductDescription-beer-4', 0, 'Rijke smaak'), ('ProductDescription-beer-4', 1, 'Rich flavor'),

('ProductTitle-beer-5', 0, 'Mira'), ('ProductTitle-beer-5', 1, 'Mira'),
('ProductDescription-beer-5', 0, 'Speciaal bier'), ('ProductDescription-beer-5', 1, 'Special beer'),

('ProductTitle-beer-6', 0, 'Duvel'), ('ProductTitle-beer-6', 1, 'Duvel'),
('ProductDescription-beer-6', 0, 'Sterk blond bier'), ('ProductDescription-beer-6', 1, 'Strong blond beer'),

('ProductTitle-beer-7', 0, 'Hoegaarden'), ('ProductTitle-beer-7', 1, 'Hoegaarden'),
('ProductDescription-beer-7', 0, 'Witbier met citrus'), ('ProductDescription-beer-7', 1, 'Wheat beer with citrus'),

('ProductTitle-beer-8', 0, 'Leffe Blond'), ('ProductTitle-beer-8', 1, 'Leffe Blond'),
('ProductDescription-beer-8', 0, 'Abdijbier'), ('ProductDescription-beer-8', 1, 'Abbey beer'),

('ProductTitle-beer-9', 0, 'Stella Artois'), ('ProductTitle-beer-9', 1, 'Stella Artois'),
('ProductDescription-beer-9', 0, 'Licht pils'), ('ProductDescription-beer-9', 1, 'Light lager'),

('ProductTitle-beer-10', 0, 'Westmalle Tripel'), ('ProductTitle-beer-10', 1, 'Westmalle Tripel'),
('ProductDescription-beer-10', 0, 'Trappistenbier'), ('ProductDescription-beer-10', 1, 'Trappist beer');

COMMIT;
