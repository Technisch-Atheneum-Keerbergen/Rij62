BEGIN;

-- ============================================
-- CATEGORY IDS (assumed):
-- 0 = Beer
-- 1 = Coffee
-- 2 = Snacks
-- ============================================

-- ============================================
-- 1. COFFEE (10 items)
-- ============================================

INSERT INTO products (title_key, description_key, price_cent, btw, stock, is_available, img_url, category_id) VALUES

('ProductTitle-coffee-espresso-001', 'ProductDescription-coffee-espresso-001', 250, 21, 100, true, '/img/coffee-espresso.jpg', 1),
('ProductTitle-coffee-cappuccino-002', 'ProductDescription-coffee-cappuccino-002', 300, 21, 100, true, '/img/coffee-cappuccino.jpg', 1),
('ProductTitle-coffee-latte-003', 'ProductDescription-coffee-latte-003', 350, 21, 100, true, '/img/coffee-latte.jpg', 1),
('ProductTitle-coffee-americano-004', 'ProductDescription-coffee-americano-004', 280, 21, 100, true, '/img/coffee-americano.jpg', 1),
('ProductTitle-coffee-flatwhite-005', 'ProductDescription-coffee-flatwhite-005', 320, 21, 100, true, '/img/coffee-flatwhite.jpg', 1),
('ProductTitle-coffee-mocha-006', 'ProductDescription-coffee-mocha-006', 380, 21, 100, true, '/img/coffee-mocha.jpg', 1),
('ProductTitle-coffee-macchiato-007', 'ProductDescription-coffee-macchiato-007', 270, 21, 100, true, '/img/coffee-macchiato.jpg', 1),
('ProductTitle-coffee-iced-008', 'ProductDescription-coffee-iced-008', 300, 21, 100, true, '/img/coffee-iced.jpg', 1),
('ProductTitle-coffee-affogato-009', 'ProductDescription-coffee-affogato-009', 400, 21, 100, true, '/img/coffee-affogato.jpg', 1),
('ProductTitle-coffee-vienna-010', 'ProductDescription-coffee-vienna-010', 350, 21, 100, true, '/img/coffee-vienna.jpg', 1);

-- Translations (Coffee)
INSERT INTO language (key, language, value) VALUES

('ProductTitle-coffee-espresso-001', 0, 'Espresso'),
('ProductTitle-coffee-espresso-001', 1, 'Espresso'),
('ProductDescription-coffee-espresso-001', 0, 'Sterke zwarte koffie'),
('ProductDescription-coffee-espresso-001', 1, 'Strong black coffee'),

('ProductTitle-coffee-cappuccino-002', 0, 'Cappuccino'),
('ProductTitle-coffee-cappuccino-002', 1, 'Cappuccino'),
('ProductDescription-coffee-cappuccino-002', 0, 'Espresso met melk en schuim'),
('ProductDescription-coffee-cappuccino-002', 1, 'Espresso with milk foam'),

('ProductTitle-coffee-latte-003', 0, 'Latte'),
('ProductTitle-coffee-latte-003', 1, 'Latte'),
('ProductDescription-coffee-latte-003', 0, 'Espresso met melk'),
('ProductDescription-coffee-latte-003', 1, 'Espresso with milk'),

('ProductTitle-coffee-americano-004', 0, 'Americano'),
('ProductTitle-coffee-americano-004', 1, 'Americano'),
('ProductDescription-coffee-americano-004', 0, 'Espresso met heet water'),
('ProductDescription-coffee-americano-004', 1, 'Espresso with hot water'),

('ProductTitle-coffee-flatwhite-005', 0, 'Flat White'),
('ProductTitle-coffee-flatwhite-005', 1, 'Flat White'),
('ProductDescription-coffee-flatwhite-005', 0, 'Espresso met romige melk'),
('ProductDescription-coffee-flatwhite-005', 1, 'Espresso with creamy milk'),

('ProductTitle-coffee-mocha-006', 0, 'Mocha'),
('ProductTitle-coffee-mocha-006', 1, 'Mocha'),
('ProductDescription-coffee-mocha-006', 0, 'Koffie met chocolade'),
('ProductDescription-coffee-mocha-006', 1, 'Coffee with chocolate'),

('ProductTitle-coffee-macchiato-007', 0, 'Macchiato'),
('ProductTitle-coffee-macchiato-007', 1, 'Macchiato'),
('ProductDescription-coffee-macchiato-007', 0, 'Espresso met beetje melk'),
('ProductDescription-coffee-macchiato-007', 1, 'Espresso with a dash of milk'),

('ProductTitle-coffee-iced-008', 0, 'Iced Coffee'),
('ProductTitle-coffee-iced-008', 1, 'Iced Coffee'),
('ProductDescription-coffee-iced-008', 0, 'Koude koffie met ijs'),
('ProductDescription-coffee-iced-008', 1, 'Cold coffee with ice'),

('ProductTitle-coffee-affogato-009', 0, 'Affogato'),
('ProductTitle-coffee-affogato-009', 1, 'Affogato'),
('ProductDescription-coffee-affogato-009', 0, 'Espresso met ijs'),
('ProductDescription-coffee-affogato-009', 1, 'Espresso with ice cream'),

('ProductTitle-coffee-vienna-010', 0, 'Weense koffie'),
('ProductTitle-coffee-vienna-010', 1, 'Vienna Coffee'),
('ProductDescription-coffee-vienna-010', 0, 'Koffie met slagroom'),
('ProductDescription-coffee-vienna-010', 1, 'Coffee with whipped cream');


-- ============================================
-- 2. SNACKS (10 items)
-- ============================================

INSERT INTO products (title_key, description_key, price_cent, btw, stock, is_available, img_url, category_id) VALUES

('ProductTitle-snacks-chips-011', 'ProductDescription-snacks-chips-011', 150, 21, 200, true, '/img/snacks-chips.jpg', 2),
('ProductTitle-snacks-nuts-012', 'ProductDescription-snacks-nuts-012', 200, 21, 200, true, '/img/snacks-nuts.jpg', 2),
('ProductTitle-snacks-pretzel-013', 'ProductDescription-snacks-pretzel-013', 220, 21, 200, true, '/img/snacks-pretzel.jpg', 2),
('ProductTitle-snacks-popcorn-014', 'ProductDescription-snacks-popcorn-014', 180, 21, 200, true, '/img/snacks-popcorn.jpg', 2),
('ProductTitle-snacks-chocolate-015', 'ProductDescription-snacks-chocolate-015', 250, 21, 200, true, '/img/snacks-chocolate.jpg', 2),
('ProductTitle-snacks-cookies-016', 'ProductDescription-snacks-cookies-016', 220, 21, 200, true, '/img/snacks-cookies.jpg', 2),
('ProductTitle-snacks-candy-017', 'ProductDescription-snacks-candy-017', 150, 21, 200, true, '/img/snacks-candy.jpg', 2),
('ProductTitle-snacks-trailmix-018', 'ProductDescription-snacks-trailmix-018', 280, 21, 200, true, '/img/snacks-trailmix.jpg', 2),
('ProductTitle-snacks-granola-019', 'ProductDescription-snacks-granola-019', 250, 21, 200, true, '/img/snacks-granola.jpg', 2),
('ProductTitle-snacks-minisandwich-020', 'ProductDescription-snacks-minisandwich-020', 300, 21, 200, true, '/img/snacks-minisandwich.jpg', 2);

-- Translations (Snacks)
INSERT INTO language (key, language, value) VALUES

('ProductTitle-snacks-chips-011', 0, 'Chips'),
('ProductTitle-snacks-chips-011', 1, 'Chips'),
('ProductDescription-snacks-chips-011', 0, 'Krokante gezouten chips'),
('ProductDescription-snacks-chips-011', 1, 'Crispy salted chips'),

('ProductTitle-snacks-nuts-012', 0, 'Noten'),
('ProductTitle-snacks-nuts-012', 1, 'Nuts'),
('ProductDescription-snacks-nuts-012', 0, 'Geroosterde notenmix'),
('ProductDescription-snacks-nuts-012', 1, 'Roasted nut mix'),

('ProductTitle-snacks-pretzel-013', 0, 'Pretzel'),
('ProductTitle-snacks-pretzel-013', 1, 'Pretzel'),
('ProductDescription-snacks-pretzel-013', 0, 'Gezouten pretzel'),
('ProductDescription-snacks-pretzel-013', 1, 'Salted pretzel'),

('ProductTitle-snacks-popcorn-014', 0, 'Popcorn'),
('ProductTitle-snacks-popcorn-014', 1, 'Popcorn'),
('ProductDescription-snacks-popcorn-014', 0, 'Boter popcorn'),
('ProductDescription-snacks-popcorn-014', 1, 'Butter popcorn'),

('ProductTitle-snacks-chocolate-015', 0, 'Chocolade'),
('ProductTitle-snacks-chocolate-015', 1, 'Chocolate'),
('ProductDescription-snacks-chocolate-015', 0, 'Melkchocolade reep'),
('ProductDescription-snacks-chocolate-015', 1, 'Milk chocolate bar'),

('ProductTitle-snacks-cookies-016', 0, 'Koekjes'),
('ProductTitle-snacks-cookies-016', 1, 'Cookies'),
('ProductDescription-snacks-cookies-016', 0, 'Assortiment koekjes'),
('ProductDescription-snacks-cookies-016', 1, 'Assorted cookies'),

('ProductTitle-snacks-candy-017', 0, 'Snoep'),
('ProductTitle-snacks-candy-017', 1, 'Candy'),
('ProductDescription-snacks-candy-017', 0, 'Gemengde snoepjes'),
('ProductDescription-snacks-candy-017', 1, 'Mixed candies'),

('ProductTitle-snacks-trailmix-018', 0, 'Trail Mix'),
('ProductTitle-snacks-trailmix-018', 1, 'Trail Mix'),
('ProductDescription-snacks-trailmix-018', 0, 'Noten en gedroogd fruit'),
('ProductDescription-snacks-trailmix-018', 1, 'Nuts and dried fruits'),

('ProductTitle-snacks-granola-019', 0, 'Granolareep'),
('ProductTitle-snacks-granola-019', 1, 'Granola Bar'),
('ProductDescription-snacks-granola-019', 0, 'Gezonde snack reep'),
('ProductDescription-snacks-granola-019', 1, 'Healthy snack bar'),

('ProductTitle-snacks-minisandwich-020', 0, 'Mini Sandwich'),
('ProductTitle-snacks-minisandwich-020', 1, 'Mini Sandwich'),
('ProductDescription-snacks-minisandwich-020', 0, 'Kleine ham-kaas sandwich'),
('ProductDescription-snacks-minisandwich-020', 1, 'Small ham-cheese sandwich');

COMMIT;