BEGIN;

INSERT INTO users(id, display_name, is_admin) VALUES (1, 'Mr delux', true);

INSERT INTO tables (table_number)
VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7);

-- =========================================================
-- LANGUAGE ENTRIES FOR NEW CATEGORIES
-- =========================================================

INSERT INTO language (key, language, value)
VALUES
-- Category Names
('CategoryName-croques', 0, 'Croques'), ('CategoryName-croques', 1, 'Croques'),
('CategoryName-coldSnacks', 0, 'Koude snacks'), ('CategoryName-coldSnacks', 1, 'Cold snacks'),
('CategoryName-warmSnacks', 0, 'Warme snacks'), ('CategoryName-warmSnacks', 1, 'Warm snacks'),
('CategoryName-dishes', 0, 'Gerechten'), ('CategoryName-dishes', 1, 'Dishes');

-- =========================================================
-- INSERT PRODUCT CATEGORIES
-- =========================================================

INSERT INTO product_categories (root_category, name_key, img_url)
VALUES
(0, 'CategoryName-croques', 'http://localhost:5148/api/image/4061ea5c-d341-483f-bce6-4750f4b750d2'),
(0, 'CategoryName-coldSnacks', 'http://localhost:5148/api/image/4133bdf9-bbbd-422a-8747-57c895adc9f2'),
(0, 'CategoryName-warmSnacks', 'http://localhost:5148/api/image/ac47e261-d0e6-4e17-bc79-2be72aaf105d'),
(0, 'CategoryName-dishes', 'http://localhost:5148/api/image/eedf2a71-0143-4af0-b4ae-87c96e3e0fbd');

-- =========================================================
-- PRODUCT TITLES AND DESCRIPTIONS (LANGUAGE ENTRIES)
-- =========================================================

-- Snacks / Sides
INSERT INTO language (key, language, value) VALUES
('ProductTitle-pita-bread-1', 0, 'Pita brood (1st.)'), ('ProductTitle-pita-bread-1', 1, 'Pita bread (1pc)'),
('ProductDescription-pita-bread-1', 0, ''), ('ProductDescription-pita-bread-1', 1, ''),
('ProductTitle-pita-bread-2', 0, 'Pita brood (2st.)'), ('ProductTitle-pita-bread-2', 1, 'Pita bread (2pcs)'),
('ProductDescription-pita-bread-2', 0, ''), ('ProductDescription-pita-bread-2', 1, ''),
('ProductTitle-sweet-potato-fries', 0, 'Zoete aardappel frietjes'), ('ProductTitle-sweet-potato-fries', 1, 'Sweet potato fries'),
('ProductDescription-sweet-potato-fries', 0, 'Met mayo'), ('ProductDescription-sweet-potato-fries', 1, 'With mayo'),
('ProductTitle-soap-of-day', 0, 'Verse soep v/d dag'), ('ProductTitle-soap-of-day', 1, 'Soup of the day'),
('ProductDescription-soap-of-day', 0, 'Met brood & boter'), ('ProductDescription-soap-of-day', 1, 'With bread & butter');

-- Croques
INSERT INTO language (key, language, value) VALUES
('ProductTitle-croque-ham-cheese', 0, 'Croque ham/kaas'), ('ProductTitle-croque-ham-cheese', 1, 'Croque ham/cheese'),
('ProductDescription-croque-ham-cheese', 0, 'Huisgemaakt brood, ketchup & mayo'), ('ProductDescription-croque-ham-cheese', 1, 'Homemade bread, ketchup & mayo'),
('ProductTitle-croque-2-cheese', 0, 'Croque met 2 kazen'), ('ProductTitle-croque-2-cheese', 1, 'Croque with 2 cheeses'),
('ProductDescription-croque-2-cheese', 0, 'Gouda & cheddar'), ('ProductDescription-croque-2-cheese', 1, 'Gouda & cheddar'),
('ProductTitle-croque-vegan', 0, 'Vegan croque'), ('ProductTitle-croque-vegan', 1, 'Vegan croque'),
('ProductDescription-croque-vegan', 0, 'Met zongedroogde tomaatjes, vegan feta, spinazie & tomaat'), ('ProductDescription-croque-vegan', 1, 'With sun-dried tomatoes, vegan feta, spinach & tomato'),
('ProductTitle-croque-kipp-haloumi', 0, 'Kip & haloumi croque'), ('ProductTitle-croque-kipp-haloumi', 1, 'Chicken & haloumi croque'),
('ProductDescription-croque-kipp-haloumi', 0, 'Rode pesto, kipfiletjes, haloumi kaas, zongedroogde tomaatjes, pesto mayo'), ('ProductDescription-croque-kipp-haloumi', 1, 'Red pesto, chicken fillet, haloumi cheese, sun-dried tomatoes, pesto mayo'),
('ProductTitle-croque-brie', 0, 'Brie Croque'), ('ProductTitle-croque-brie', 1, 'Brie Croque'),
('ProductDescription-croque-brie', 0, 'Brie, walnoten, tijm & uienconfijt'), ('ProductDescription-croque-brie', 1, 'Brie, walnuts, thyme & onion confit');

-- Cold Snacks
INSERT INTO language (key, language, value) VALUES
('ProductTitle-labneh', 0, 'Labneh'), ('ProductTitle-labneh', 1, 'Labneh'),
('ProductDescription-labneh', 0, 'Met zongedroogde tomaatjes, pijnboompitten, olijfolie & dadeslaus'), ('ProductDescription-labneh', 1, 'With sun-dried tomatoes, pine nuts, olive oil & date sauce'),
('ProductTitle-hummus', 0, 'Hummus'), ('ProductTitle-hummus', 1, 'Hummus'),
('ProductDescription-hummus', 0, 'Standaard'), ('ProductDescription-hummus', 1, 'Standard'),
('ProductTitle-hummus-chili', 0, 'Hummus met chili'), ('ProductTitle-hummus-chili', 1, 'Hummus with chili'),
('ProductDescription-hummus-chili', 0, 'Met chili, olijven, gepekelde ui'), ('ProductDescription-hummus-chili', 1, 'With chili, olives, pickled onion'),
('ProductTitle-salad-croques', 0, 'Slaatje voor bij de croques'), ('ProductTitle-salad-croques', 1, 'Side salad for croques'),
('ProductDescription-salad-croques', 0, ''), ('ProductDescription-salad-croques', 1, '');

-- Warm Snacks
INSERT INTO language (key, language, value) VALUES
('ProductTitle-stuffed-pastry', 0, 'Gebakken gevulde deeghapje'), ('ProductTitle-stuffed-pastry', 1, 'Fried stuffed pastry'),
('ProductDescription-stuffed-pastry', 0, 'Met feta in een krokant "jasje" met honing en sesamzaadjes'), ('ProductDescription-stuffed-pastry', 1, 'With feta in a crispy "jacket" with honey and sesame seeds'),
('ProductTitle-grilled-haloumi', 0, 'Gegrilde haloumi kaas'), ('ProductTitle-grilled-haloumi', 1, 'Grilled haloumi cheese'),
('ProductDescription-grilled-haloumi', 0, 'Met zongedroogde tomaatjes & verse munt'), ('ProductDescription-grilled-haloumi', 1, 'With sun-dried tomatoes & fresh mint');

-- Dishes
INSERT INTO language (key, language, value) VALUES
('ProductTitle-smoked-salmon-sandwich', 0, 'Boterham gerookte zalm'), ('ProductTitle-smoked-salmon-sandwich', 1, 'Smoked salmon sandwich'),
('ProductDescription-smoked-salmon-sandwich', 0, 'Sla, avocado, komkommer, tartaarsaus, gepekelde ajuin, soja sesamsaus en sesamzaadjes op een zachte of geroosterde boterham'), ('ProductDescription-smoked-salmon-sandwich', 1, 'Lettuce, avocado, cucumber, tartar sauce, pickled onion, soy sesame sauce and sesame seeds on a soft or toasted sandwich'),
('ProductTitle-falafel', 0, 'Falafel balletjes'), ('ProductTitle-falafel', 1, 'Falafel balls'),
('ProductDescription-falafel', 0, 'Vegan kikkererwten balletjes om te dippen in een yoghurt-tahini sausje'), ('ProductDescription-falafel', 1, 'Vegan chickpea balls to dip in a yogurt-tahini sauce'),
('ProductTitle-focaccia-rosemary', 0, 'Focaccia rozemarijn'), ('ProductTitle-focaccia-rosemary', 1, 'Rosemary focaccia'),
('ProductDescription-focaccia-rosemary', 0, 'Met mozzarella, kerstomaatjes, prosciutto, pijnboompitjes & rucola. Geserveerd met slaatje & potje pesto mayo.'), ('ProductDescription-focaccia-rosemary', 1, 'With mozzarella, cherry tomatoes, prosciutto, pine nuts & arugula. Served with side salad & pot of pesto mayo.'),
('ProductTitle-focaccia-rosemary-veg', 0, 'Focaccia rozemarijn (vegetarisch)'), ('ProductTitle-focaccia-rosemary-veg', 1, 'Rosemary focaccia (vegetarian)'),
('ProductDescription-focaccia-rosemary-veg', 0, 'Met mozzarella, kerstomaatjes, pijnboompitjes & rucola. Geserveerd met slaatje & potje pesto mayo.'), ('ProductDescription-focaccia-rosemary-veg', 1, 'With mozzarella, cherry tomatoes, pine nuts & arugula. Served with side salad & pot of pesto mayo.'),
('ProductTitle-curry-chicken', 0, 'Carrieban kip'), ('ProductTitle-curry-chicken', 1, 'Curry chicken'),
('ProductDescription-curry-chicken', 0, 'Krokante kippenhaasjes met verse gegrilde ananas, koolslaatje, zoete chilisaus, honing mosterd saus'), ('ProductDescription-curry-chicken', 1, 'Crispy chicken tenders with fresh grilled pineapple, coleslaw, sweet chili sauce, honey mustard sauce'),
('ProductTitle-salad-rij62', 0, 'Salade Rij62'), ('ProductTitle-salad-rij62', 1, 'Salad Rij62'),
('ProductDescription-salad-rij62', 0, 'Sla, geitenkaas, kerstomaatjes, komkommer, appel, noten, gedroogde vijgen & honing mosterd saus, met brood'), ('ProductDescription-salad-rij62', 1, 'Lettuce, goat cheese, cherry tomatoes, cucumber, apple, nuts, dried figs & honey mustard sauce, with bread');

-- Suggestions
INSERT INTO language (key, language, value) VALUES
('ProductTitle-bacon-cheese-burger', 0, 'Bacon Cheese Burger'), ('ProductTitle-bacon-cheese-burger', 1, 'Bacon Cheese Burger'),
('ProductDescription-bacon-cheese-burger', 0, 'Huisgemaakte rundsburger (puur) met cheddarkaas, spek, sla, tomaat, gepekelde ui & saus'), ('ProductDescription-bacon-cheese-burger', 1, 'Homemade beef burger (pure) with cheddar cheese, bacon, lettuce, tomato, pickled onion & sauce');

-- Extras
INSERT INTO language (key, language, value)
VALUES
('ProductTitle-ketchup', 0, 'Ketchup'), ('ProductTitle-ketchup', 1, 'Ketchup'),
('ProductDescription-ketchup', 0, ''), ('ProductDescription-ketchup', 1, ''),
('ProductTitle-mayo', 0, 'Mayonaise'), ('ProductTitle-mayo', 1, 'Mayonnaise'),
('ProductDescription-mayo', 0, ''), ('ProductDescription-mayo', 1, '');

-- =========================================================
-- INSERT PRODUCTS
-- =========================================================

-- Snacks / Sides (category_id = 1, assuming snacks category gets id 1)
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-pita-bread-1','ProductDescription-pita-bread-1',3.50,21,100,true,'http://localhost:5148/api/image/808188cd-bc34-4eac-9d16-b565b157fbd4',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-pita-bread-2','ProductDescription-pita-bread-2',6.50,21,100,true,'http://localhost:5148/api/image/808188cd-bc34-4eac-9d16-b565b157fbd4',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-sweet-potato-fries','ProductDescription-sweet-potato-fries',8.90,21,100,true,'http://localhost:5148/api/image/ac47e261-d0e6-4e17-bc79-2be72aaf105d',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-soap-of-day','ProductDescription-soap-of-day',8.00,21,100,true,'http://localhost:5148/api/image/d178e073-842e-41f2-891f-76bd89defd65',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks'));

-- Croques (category_id for croques)
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-croque-ham-cheese','ProductDescription-croque-ham-cheese',8.00,21,100,true,'http://localhost:5148/api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-2-cheese','ProductDescription-croque-2-cheese',8.00,21,100,true,'http://localhost:5148/api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-vegan','ProductDescription-croque-vegan',8.00,21,100,true,'http://localhost:5148/api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-kipp-haloumi','ProductDescription-croque-kipp-haloumi',8.00,21,100,true,'http://localhost:5148/api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-brie','ProductDescription-croque-brie',8.00,21,100,true,'http://localhost:5148/api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques'));

-- Cold Snacks
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-labneh','ProductDescription-labneh',8.90,21,100,true,'http://localhost:5148/api/image/ec982685-b202-4e19-90a2-c759dd921d78',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks')),
('ProductTitle-hummus','ProductDescription-hummus',6.90,21,100,true,'http://localhost:5148/api/image/4133bdf9-bbbd-422a-8747-57c895adc9f2',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks')),
('ProductTitle-hummus-chili','ProductDescription-hummus-chili',7.90,21,100,true,'http://localhost:5148/api/image/8d9e61ee-d4b7-4107-8882-4aa1c9dd1696',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks')),
('ProductTitle-salad-croques','ProductDescription-salad-croques',5.00,21,100,true,'http://localhost:5148/api/image/70a2f147-2671-4a8b-b16e-be701a6188f4',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks'));

-- Warm Snacks
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-stuffed-pastry','ProductDescription-stuffed-pastry',9.50,21,100,true,'http://localhost:5148/api/image/ff330f5f-02b6-4ae4-8e03-ace122386365',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-grilled-haloumi','ProductDescription-grilled-haloumi',9.50,21,100,true,'http://localhost:5148/api/image/cab8218e-1d66-47ed-94a2-20f8f59e2aca',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks'));

-- Dishes
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-smoked-salmon-sandwich','ProductDescription-smoked-salmon-sandwich',16.0,21,100,true,'http://localhost:5148/api/image/eedf2a71-0143-4af0-b4ae-87c96e3e0fbd',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-falafel','ProductDescription-falafel',10.00,21,100,true,'http://localhost:5148/api/image/cbec4131-099a-45d8-a82d-bbe67dd54bbf',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-focaccia-rosemary','ProductDescription-focaccia-rosemary',16.9,21,100,true,'http://localhost:5148/api/image/7ccb7ca2-3bb0-4bf1-b24d-c3fc07c88951',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-focaccia-rosemary-veg','ProductDescription-focaccia-rosemary-veg',16.9,21,100,true,'http://localhost:5148/api/image/7ccb7ca2-3bb0-4bf1-b24d-c3fc07c88951',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-curry-chicken','ProductDescription-curry-chicken',17.90,21,100,true,'http://localhost:5148/api/image/75620eea-1c53-4bc9-9fa7-e3d4b22362b7',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-salad-rij62','ProductDescription-salad-rij62',23.5,21,100,true,'http://localhost:5148/api/image/70a2f147-2671-4a8b-b16e-be701a6188f4',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-bacon-cheese-burger','ProductDescription-bacon-cheese-burger',13.5,21,100,true,'http://localhost:5148/api/image/ab38967d-4522-4219-bf94-e5181e013651',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes'));


-- Extras
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-ketchup', 'ProductDescription-ketchup', 0, 21, 100, true, 'http://localhost:5148/api/image/35fe8882-d8cb-4a0e-a896-a2b06b63d1b8', (SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-mayo', 'ProductDescription-mayo', 0, 21, 100, true, 'http://localhost:5148/api/image/02f88d3c-e899-440f-840f-396eed4af598', (SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks'));


-- =========================================================
-- INSERT PRODUCT STEP TITLES (LANGUAGE ENTRIES)
-- =========================================================

INSERT INTO language (key, language, value)
VALUES
('ProductStep-choose-a-sauce', 0, 'Kies een saus'), ('ProductStep-choose-a-sauce', 1, 'Choose a sauce');

-- =========================================================
-- INSERT PRODUCT STEPS
-- =========================================================

INSERT INTO product_steps(title_key, product_id, default_option_id, multiple_choice)
VALUES
('ProductStep-choose-a-sauce', (SELECT id FROM products WHERE title_key='ProductTitle-croque-ham-cheese'), NULL, TRUE);

INSERT INTO product_step_options(product_step_id, product_id)
VALUES
((SELECT id FROM product_steps WHERE title_key='ProductStep-choose-a-sauce'), (SELECT id FROM products WHERE title_key='ProductTitle-ketchup')),
((SELECT id FROM product_steps WHERE title_key='ProductStep-choose-a-sauce'), (SELECT id FROM products WHERE title_key='ProductTitle-mayo'));

COMMIT
