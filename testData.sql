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
(0, 'CategoryName-croques', 'api/image/4061ea5c-d341-483f-bce6-4750f4b750d2'),
(0, 'CategoryName-coldSnacks', 'api/image/4133bdf9-bbbd-422a-8747-57c895adc9f2'),
(0, 'CategoryName-warmSnacks', 'api/image/ac47e261-d0e6-4e17-bc79-2be72aaf105d'),
(0, 'CategoryName-dishes', 'api/image/eedf2a71-0143-4af0-b4ae-87c96e3e0fbd');

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
-- INSERT PRODUCT STEP TITLES (LANGUAGE ENTRIES)
-- =========================================================

INSERT INTO language (key, language, value)
VALUES
('ProductStep-coffee-extras', 0, 'Kies extras'), ('ProductStep-coffee-extras', 1, 'Choose a extras');

-- =========================================================
-- INSERT PRODUCTS
-- =========================================================

-- Snacks / Sides (category_id = 1, assuming snacks category gets id 1)
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-pita-bread-1','ProductDescription-pita-bread-1',3.50,21,100,true,'api/image/808188cd-bc34-4eac-9d16-b565b157fbd4',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-pita-bread-2','ProductDescription-pita-bread-2',6.50,21,100,true,'api/image/808188cd-bc34-4eac-9d16-b565b157fbd4',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-sweet-potato-fries','ProductDescription-sweet-potato-fries',8.90,21,100,true,'api/image/ac47e261-d0e6-4e17-bc79-2be72aaf105d',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-soap-of-day','ProductDescription-soap-of-day',8.00,21,100,true,'api/image/d178e073-842e-41f2-891f-76bd89defd65',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks'));

-- Croques (category_id for croques)
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-croque-ham-cheese','ProductDescription-croque-ham-cheese',8.00,21,100,true,'api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-2-cheese','ProductDescription-croque-2-cheese',8.00,21,100,true,'api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-vegan','ProductDescription-croque-vegan',8.00,21,100,true,'api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-kipp-haloumi','ProductDescription-croque-kipp-haloumi',8.00,21,100,true,'api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques')),
('ProductTitle-croque-brie','ProductDescription-croque-brie',8.00,21,100,true,'api/image/4061ea5c-d341-483f-bce6-4750f4b750d2',(SELECT id FROM product_categories WHERE name_key='CategoryName-croques'));

-- Cold Snacks
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-labneh','ProductDescription-labneh',8.90,21,100,true,'api/image/ec982685-b202-4e19-90a2-c759dd921d78',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks')),
('ProductTitle-hummus','ProductDescription-hummus',6.90,21,100,true,'api/image/4133bdf9-bbbd-422a-8747-57c895adc9f2',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks')),
('ProductTitle-hummus-chili','ProductDescription-hummus-chili',7.90,21,100,true,'api/image/8d9e61ee-d4b7-4107-8882-4aa1c9dd1696',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks')),
('ProductTitle-salad-croques','ProductDescription-salad-croques',5.00,21,100,true,'api/image/70a2f147-2671-4a8b-b16e-be701a6188f4',(SELECT id FROM product_categories WHERE name_key='CategoryName-coldSnacks'));

-- Warm Snacks
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-stuffed-pastry','ProductDescription-stuffed-pastry',9.50,21,100,true,'api/image/ff330f5f-02b6-4ae4-8e03-ace122386365',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-grilled-haloumi','ProductDescription-grilled-haloumi',9.50,21,100,true,'api/image/cab8218e-1d66-47ed-94a2-20f8f59e2aca',(SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks'));

-- Dishes
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-smoked-salmon-sandwich','ProductDescription-smoked-salmon-sandwich',16.0,21,100,true,'api/image/eedf2a71-0143-4af0-b4ae-87c96e3e0fbd',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-falafel','ProductDescription-falafel',10.00,21,100,true,'api/image/cbec4131-099a-45d8-a82d-bbe67dd54bbf',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-focaccia-rosemary','ProductDescription-focaccia-rosemary',16.9,21,100,true,'api/image/7ccb7ca2-3bb0-4bf1-b24d-c3fc07c88951',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-focaccia-rosemary-veg','ProductDescription-focaccia-rosemary-veg',16.9,21,100,true,'api/image/7ccb7ca2-3bb0-4bf1-b24d-c3fc07c88951',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-curry-chicken','ProductDescription-curry-chicken',17.90,21,100,true,'api/image/75620eea-1c53-4bc9-9fa7-e3d4b22362b7',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-salad-rij62','ProductDescription-salad-rij62',23.5,21,100,true,'api/image/70a2f147-2671-4a8b-b16e-be701a6188f4',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes')),
('ProductTitle-bacon-cheese-burger','ProductDescription-bacon-cheese-burger',13.5,21,100,true,'api/image/ab38967d-4522-4219-bf94-e5181e013651',(SELECT id FROM product_categories WHERE name_key='CategoryName-dishes'));


-- Extras
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-ketchup', 'ProductDescription-ketchup', 0, 21, 100, true, 'api/image/35fe8882-d8cb-4a0e-a896-a2b06b63d1b8', (SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks')),
('ProductTitle-mayo', 'ProductDescription-mayo', 0, 21, 100, true, 'api/image/02f88d3c-e899-440f-840f-396eed4af598', (SELECT id FROM product_categories WHERE name_key='CategoryName-warmSnacks'));


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


-- =====================================================
-- Language entries for drink categories
-- =====================================================
INSERT INTO language (key, language, value) VALUES
-- Categories
('CategoryName-coffee', 0, 'Koffies'), ('CategoryName-coffee', 1, 'Coffees'),
('CategoryName-coffeeWithMilk', 0, 'Koffies met Melk'), ('CategoryName-coffeeWithMilk', 1, 'Coffees with Milk'),
('CategoryName-specialCoffee', 0, 'Speciale Koffies'), ('CategoryName-specialCoffee', 1, 'Special Coffees'),
('CategoryName-hotChocolate', 0, 'Warme Chocomelk'), ('CategoryName-hotChocolate', 1, 'Hot Chocolate'),
('CategoryName-chaiLatte', 0, 'Chai Latte'), ('CategoryName-chaiLatte', 1, 'Chai Latte'),
('CategoryName-icedCoffees', 0, 'IJskoffie'), ('CategoryName-icedCoffees', 1, 'Iced Coffees'),
('CategoryName-ortea', 0, 'Tea'), ('CategoryName-ortea', 1, 'Thee'),
('CategoryName-homemadeTea', 0, 'Huisgemaakte Thee'), ('CategoryName-homemadeTea', 1, 'Homemade Tea'),
('CategoryName-extras', 0, 'Extra''s'), ('CategoryName-extras', 1, 'Extras'),
('CategoryName-softDrinks', 0, 'Frisdranken & Limonades & Sappen'), ('CategoryName-softDrinks', 1, 'Soft Drinks & Lemonades & Juices'),
('CategoryName-beerWineCocktails', 0, 'Bier, Wijn & Cocktails'), ('CategoryName-beerWineCocktails', 1, 'Beer, Wine & Cocktails'),
('CategoryName-mocktails', 0, 'Mocktails'), ('CategoryName-mocktails', 1, 'Mocktails');

-- =====================================================
-- Language entries for products
-- =====================================================
-- Koffies / Coffees
INSERT INTO language (key, language, value) VALUES
('ProductTitle-espresso', 0, 'Espresso'), ('ProductTitle-espresso', 1, 'Espresso'),
('ProductDescription-espresso', 0, ''), ('ProductDescription-espresso', 1, ''),
('ProductTitle-koffie', 0, 'Koffie'), ('ProductTitle-koffie', 1, 'Coffee'),
('ProductDescription-koffie', 0, ''), ('ProductDescription-koffie', 1, ''),
('ProductTitle-doppio', 0, 'Doppio'), ('ProductTitle-doppio', 1, 'Doppio'),
('ProductDescription-doppio', 0, ''), ('ProductDescription-doppio', 1, ''),
('ProductTitle-amerikano', 0, 'Amerikano'), ('ProductTitle-amerikano', 1, 'Americano'),
('ProductDescription-amerikano', 0, ''), ('ProductDescription-amerikano', 1, ''),

-- Koffies met melk / Coffees with milk
('ProductTitle-cortado', 0, 'Cortado'), ('ProductTitle-cortado', 1, 'Cortado'),
('ProductDescription-cortado', 0, ''), ('ProductDescription-cortado', 1, ''),
('ProductTitle-cappuccino', 0, 'Cappuccino'), ('ProductTitle-cappuccino', 1, 'Cappuccino'),
('ProductDescription-cappuccino', 0, ''), ('ProductDescription-cappuccino', 1, ''),
('ProductTitle-latte', 0, 'Latte'), ('ProductTitle-latte', 1, 'Latte'),
('ProductDescription-latte', 0, ''), ('ProductDescription-latte', 1, ''),
('ProductTitle-flatWhite', 0, 'Flat White'), ('ProductTitle-flatWhite', 1, 'Flat White'),
('ProductDescription-flatWhite', 0, ''), ('ProductDescription-flatWhite', 1, ''),

-- Speciale koffies / Special coffees
('ProductTitle-conPanna', 0, 'Con Panna'), ('ProductTitle-conPanna', 1, 'Con Panna'),
('ProductDescription-conPanna', 0, ''), ('ProductDescription-conPanna', 1, ''),
('ProductTitle-hotAndSpiced', 0, 'Hot & Spiced'), ('ProductTitle-hotAndSpiced', 1, 'Hot & Spiced'),
('ProductDescription-hotAndSpiced', 0, 'Latte met kruiden & honing'), ('ProductDescription-hotAndSpiced', 1, 'Latte with spices & honey'),
('ProductTitle-chococcino', 0, 'Chococcino'), ('ProductTitle-chococcino', 1, 'Chococcino'),
('ProductDescription-chococcino', 0, 'Chocomelk + shot koffie'), ('ProductDescription-chococcino', 1, 'Hot chocolate + coffee shot'),
('ProductTitle-mokka', 0, 'Mokka'), ('ProductTitle-mokka', 1, 'Mocha'),
('ProductDescription-mokka', 0, 'Met donkere chocoladebonen'), ('ProductDescription-mokka', 1, 'With dark chocolate beans'),
('ProductTitle-gemberccino', 0, 'Gemberccino'), ('ProductTitle-gemberccino', 1, 'Gingerccino'),
('ProductDescription-gemberccino', 0, 'Gemberpoeder, witte chocolade & honing'), ('ProductDescription-gemberccino', 1, 'Ginger powder, white chocolate & honey'),
('ProductTitle-latteSlagroom', 0, 'Latte Slagroom'), ('ProductTitle-latteSlagroom', 1, 'Latte with Whipped Cream'),
('ProductDescription-latteSlagroom', 0, ''), ('ProductDescription-latteSlagroom', 1, ''),

-- Warme chocomelk / Hot chocolate
('ProductTitle-swirlyHotChocolate', 0, 'Swirly Hot Chocolate'), ('ProductTitle-swirlyHotChocolate', 1, 'Swirly Hot Chocolate'),
('ProductDescription-swirlyHotChocolate', 0, 'Van Baru'), ('ProductDescription-swirlyHotChocolate', 1, 'From Baru'),
('ProductTitle-chocoladeboontjes', 0, 'Chocoladeboontjes'), ('ProductTitle-chocoladeboontjes', 1, 'Chocolate Beans'),
('ProductDescription-chocoladeboontjes', 0, 'Wit, melk, puur'), ('ProductDescription-chocoladeboontjes', 1, 'White, milk, dark'),

-- Chai latte
('ProductTitle-chaiLatte', 0, 'Chai Latte'), ('ProductTitle-chaiLatte', 1, 'Chai Latte'),
('ProductDescription-chaiLatte', 0, 'Massala, vanille, cardemon, kaneel, lemongrass, matcha, kurkuma'), ('ProductDescription-chaiLatte', 1, 'Massala, vanilla, cardamom, cinnamon, lemongrass, matcha, turmeric'),
('ProductTitle-dirtyChai', 0, 'Dirty Chai'), ('ProductTitle-dirtyChai', 1, 'Dirty Chai'),
('ProductDescription-dirtyChai', 0, 'Chai met extra shot koffie'), ('ProductDescription-dirtyChai', 1, 'Chai with extra coffee shot'),
('ProductTitle-matchaLatte', 0, 'Matcha Latte'), ('ProductTitle-matchaLatte', 1, 'Matcha Latte'),
('ProductDescription-matchaLatte', 0, 'Puur'), ('ProductDescription-matchaLatte', 1, 'Pure'),

-- Iced koffies / Iced coffees
('ProductTitle-icedLatte', 0, 'Iced Latte'), ('ProductTitle-icedLatte', 1, 'Iced Latte'),
('ProductDescription-icedLatte', 0, ''), ('ProductDescription-icedLatte', 1, ''),
('ProductTitle-icedLongBlack', 0, 'Iced Long Black'), ('ProductTitle-icedLongBlack', 1, 'Iced Long Black'),
('ProductDescription-icedLongBlack', 0, ''), ('ProductDescription-icedLongBlack', 1, ''),
('ProductTitle-icedChaiLatte', 0, 'Iced Chai Latte'), ('ProductTitle-icedChaiLatte', 1, 'Iced Chai Latte'),
('ProductDescription-icedChaiLatte', 0, ''), ('ProductDescription-icedChaiLatte', 1, ''),
('ProductTitle-icedMatcha', 0, 'Iced Matcha'), ('ProductTitle-icedMatcha', 1, 'Iced Matcha'),
('ProductDescription-icedMatcha', 0, ''), ('ProductDescription-icedMatcha', 1, ''),

-- Tea
('ProductTitle-tiffanysBreakfast', 0, 'Tiffany''s Breakfast'), ('ProductTitle-tiffanysBreakfast', 1, 'Tiffany''s Breakfast'),
('ProductDescription-tiffanysBreakfast', 0, 'Zwarte thee'), ('ProductDescription-tiffanysBreakfast', 1, 'Black tea'),
('ProductTitle-dukesBlue', 0, 'Duke''s Blue'), ('ProductTitle-dukesBlue', 1, 'Duke''s Blue'),
('ProductDescription-dukesBlue', 0, 'Earl Grey'), ('ProductDescription-dukesBlue', 1, 'Earl Grey'),
('ProductTitle-mountFeather', 0, 'Mount Feather'), ('ProductTitle-mountFeather', 1, 'Mount Feather'),
('ProductDescription-mountFeather', 0, 'Groene thee'), ('ProductDescription-mountFeather', 1, 'Green tea'),
('ProductTitle-lycheeWhitePeony', 0, 'Lychee White Peony'), ('ProductTitle-lycheeWhitePeony', 1, 'Lychee White Peony'),
('ProductDescription-lycheeWhitePeony', 0, 'Witte thee'), ('ProductDescription-lycheeWhitePeony', 1, 'White tea'),
('ProductTitle-beCamomile', 0, 'Be Camomile'), ('ProductTitle-beCamomile', 1, 'Be Camomile'),
('ProductDescription-beCamomile', 0, 'Kamille'), ('ProductDescription-beCamomile', 1, 'Camomile'),
('ProductTitle-laVieEnRose', 0, 'La Vie en Rose'), ('ProductTitle-laVieEnRose', 1, 'La Vie en Rose'),
('ProductDescription-laVieEnRose', 0, 'Rozebottel'), ('ProductDescription-laVieEnRose', 1, 'Rosehip'),
('ProductTitle-kungFuFighter', 0, 'Kung Fu Fighter'), ('ProductTitle-kungFuFighter', 1, 'Kung Fu Fighter'),
('ProductDescription-kungFuFighter', 0, 'Infusie van appel, eucalyptus, gember & sinaasappelzeste'), ('ProductDescription-kungFuFighter', 1, 'Infusion of apple, eucalyptus, ginger & orange zest'),

-- Huisgemaakte thee / Homemade tea
('ProductTitle-karkadeh', 0, 'Karkadeh'), ('ProductTitle-karkadeh', 1, 'Karkadeh'),
('ProductDescription-karkadeh', 0, 'Hibiscus, appelsien & munt'), ('ProductDescription-karkadeh', 1, 'Hibiscus, orange & mint'),
('ProductTitle-verseMunt', 0, 'Verse Munt'), ('ProductTitle-verseMunt', 1, 'Fresh Mint'),
('ProductDescription-verseMunt', 0, 'Puur'), ('ProductDescription-verseMunt', 1, 'Pure'),
('ProductTitle-verseGember', 0, 'Verse Gember'), ('ProductTitle-verseGember', 1, 'Fresh Ginger'),
('ProductDescription-verseGember', 0, 'Puur'), ('ProductDescription-verseGember', 1, 'Pure'),
('ProductTitle-yuzuThee', 0, 'Yuzu Thee'), ('ProductTitle-yuzuThee', 1, 'Yuzu Tea'),
('ProductDescription-yuzuThee', 0, 'Yuzu-puree, sinaas, zwarte thee, munt'), ('ProductDescription-yuzuThee', 1, 'Yuzu puree, orange, black tea, mint'),
('ProductTitle-passievruchtThee', 0, 'Passievrucht Thee'), ('ProductTitle-passievruchtThee', 1, 'Passion Fruit Tea'),
('ProductDescription-passievruchtThee', 0, 'Passievrucht-puree, citroen, zwarte thee, munt'), ('ProductDescription-passievruchtThee', 1, 'Passion fruit puree, lemon, black tea, mint'),

-- Extra's / Extras
('ProductTitle-smaaksiropen', 0, 'Smaaksiropen'), ('ProductTitle-smaaksiropen', 1, 'Flavor Syrups'),
('ProductDescription-smaaksiropen', 0, 'Caramel, vanille, hazelnoot, speculoos'), ('ProductDescription-smaaksiropen', 1, 'Caramel, vanilla, hazelnut, speculoos'),
('ProductTitle-honing', 0, 'Honing'), ('ProductTitle-honing', 1, 'Honey'),
('ProductDescription-honing', 0, ''), ('ProductDescription-honing', 1, ''),
('ProductTitle-havermelk', 0, 'Havermelk'), ('ProductTitle-havermelk', 1, 'Oat milk'),
('ProductDescription-havermelk', 0, ''), ('ProductDescription-havermelk', 1, ''),
('ProductTitle-slagroom', 0, 'Slagroom'), ('ProductTitle-slagroom', 1, 'Whipped cream'),
('ProductDescription-slagroom', 0, ''), ('ProductDescription-slagroom', 1, ''),
('ProductTitle-espressoShot', 0, 'Espresso Shot'), ('ProductTitle-espressoShot', 1, 'Espresso Shot'),
('ProductDescription-espressoShot', 0, ''), ('ProductDescription-espressoShot', 1, ''),

-- Frisdranken & limonades & sappen / Soft drinks & lemonades & juices
('ProductTitle-water', 0, 'Water'), ('ProductTitle-water', 1, 'Water'),
('ProductDescription-water', 0, 'Plat of bruis'), ('ProductDescription-water', 1, 'Still or sparkling'),
('ProductTitle-cola', 0, 'Cola'), ('ProductTitle-cola', 1, 'Cola'),
('ProductDescription-cola', 0, 'Cola of cola zero'), ('ProductDescription-cola', 1, 'Cola or cola zero'),
('ProductTitle-tonic', 0, 'Tonic'), ('ProductTitle-tonic', 1, 'Tonic'),
('ProductDescription-tonic', 0, ''), ('ProductDescription-tonic', 1, ''),
('ProductTitle-vruchtensapStandaard', 0, 'Vruchtensap'), ('ProductTitle-vruchtensapStandaard', 1, 'Fruit juice'),
('ProductDescription-vruchtensapStandaard', 0, 'Appelsien, multivitaminen, appel, pompelmoes'), ('ProductDescription-vruchtensapStandaard', 1, 'Orange, multivitamin, apple, grapefruit'),
('ProductTitle-appelKersVruchtensap', 0, 'Appel-Kers Vruchtensap'), ('ProductTitle-appelKersVruchtensap', 1, 'Apple-Cherry Fruit juice'),
('ProductDescription-appelKersVruchtensap', 0, ''), ('ProductDescription-appelKersVruchtensap', 1, ''),
('ProductTitle-fentimans', 0, 'Fentimans'), ('ProductTitle-fentimans', 1, 'Fentimans'),
('ProductDescription-fentimans', 0, 'Rose, Elderflower, Raspberry, Orange-mandarine'), ('ProductDescription-fentimans', 1, 'Rose, Elderflower, Raspberry, Orange-mandarin'),
('ProductTitle-ritchiesLimo', 0, 'Ritchies Limo'), ('ProductTitle-ritchiesLimo', 1, 'Ritchies Lemonade'),
('ProductDescription-ritchiesLimo', 0, 'Citroen-framboos'), ('ProductDescription-ritchiesLimo', 1, 'Lemon-raspberry'),
('ProductTitle-gemberCitroenLimo', 0, 'Gember-Citroen Limo'), ('ProductTitle-gemberCitroenLimo', 1, 'Ginger-Lemon Lemonade'),
('ProductDescription-gemberCitroenLimo', 0, 'Huisgemaakt'), ('ProductDescription-gemberCitroenLimo', 1, 'Homemade'),
('ProductTitle-iceTea', 0, 'Ice Tea'), ('ProductTitle-iceTea', 1, 'Ice Tea'),
('ProductDescription-iceTea', 0, 'Huisgemaakt'), ('ProductDescription-iceTea', 1, 'Homemade'),

-- Bier, wijn & cocktails / Beer, wine & cocktails
('ProductTitle-pintje', 0, 'Pintje'), ('ProductTitle-pintje', 1, 'Pintje'),
('ProductDescription-pintje', 0, ''), ('ProductDescription-pintje', 1, ''),
('ProductTitle-bast', 0, 'Bast'), ('ProductTitle-bast', 1, 'Bast'),
('ProductDescription-bast', 0, 'Uit Herentals'), ('ProductDescription-bast', 1, 'From Herentals'),
('ProductTitle-zwaardereBieren', 0, 'Zwaardere Bieren'), ('ProductTitle-zwaardereBieren', 1, 'Stronger Beers'),
('ProductDescription-zwaardereBieren', 0, 'La Chouffe (blond), Karmeliet (tripel), Duvel, Nethe tripel'), ('ProductDescription-zwaardereBieren', 1, 'La Chouffe (blond), Karmeliet (tripel), Duvel, Nethe tripel'),
('ProductTitle-liefmans0', 0, 'Liefmans 0%'), ('ProductTitle-liefmans0', 1, 'Liefmans 0%'),
('ProductDescription-liefmans0', 0, ''), ('ProductDescription-liefmans0', 1, ''),
('ProductTitle-wijn', 0, 'Wijn'), ('ProductTitle-wijn', 1, 'Wine'),
('ProductDescription-wijn', 0, 'Rood, wit, rosé'), ('ProductDescription-wijn', 1, 'Red, white, rosé'),
('ProductTitle-cava', 0, 'Cava'), ('ProductTitle-cava', 1, 'Cava'),
('ProductDescription-cava', 0, ''), ('ProductDescription-cava', 1, ''),
('ProductTitle-belliniMartini', 0, 'Bellini Martini'), ('ProductTitle-belliniMartini', 1, 'Bellini Martini'),
('ProductDescription-belliniMartini', 0, ''), ('ProductDescription-belliniMartini', 1, ''),
('ProductTitle-hugo', 0, 'Hugo'), ('ProductTitle-hugo', 1, 'Hugo'),
('ProductDescription-hugo', 0, ''), ('ProductDescription-hugo', 1, ''),
('ProductTitle-aperol', 0, 'Aperol'), ('ProductTitle-aperol', 1, 'Aperol'),
('ProductDescription-aperol', 0, ''), ('ProductDescription-aperol', 1, ''),
('ProductTitle-mojito', 0, 'Mojito'), ('ProductTitle-mojito', 1, 'Mojito'),
('ProductDescription-mojito', 0, ''), ('ProductDescription-mojito', 1, ''),
('ProductTitle-ginTonic', 0, 'Gin Tonic'), ('ProductTitle-ginTonic', 1, 'Gin Tonic'),
('ProductDescription-ginTonic', 0, ''), ('ProductDescription-ginTonic', 1, ''),

-- Mocktails
('ProductTitle-yellowSunrise', 0, 'Yellow Sunrise'), ('ProductTitle-yellowSunrise', 1, 'Yellow Sunrise'),
('ProductDescription-yellowSunrise', 0, 'Op basis van appel en vanille'), ('ProductDescription-yellowSunrise', 1, 'Based on apple and vanilla'),
('ProductTitle-redSunset', 0, 'Red Sunset'), ('ProductTitle-redSunset', 1, 'Red Sunset'),
('ProductDescription-redSunset', 0, 'Op basis van aardbei en kokos'), ('ProductDescription-redSunset', 1, 'Based on strawberry and coconut'),
('ProductTitle-virginMojito', 0, 'Virgin Mojito'), ('ProductTitle-virginMojito', 1, 'Virgin Mojito'),
('ProductDescription-virginMojito', 0, ''), ('ProductDescription-virginMojito', 1, '');

-- =====================================================
-- Insert product categories (root_category = 1 for Drinks)
-- =====================================================
INSERT INTO product_categories (root_category, name_key, img_url) VALUES
(1, 'CategoryName-coffee', 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1'),
(1, 'CategoryName-coffeeWithMilk', 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1'),
(1, 'CategoryName-specialCoffee', 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1'),
(1, 'CategoryName-hotChocolate', 'api/image/65974cdc-9bf9-4c80-a157-3148692bd513'),
(1, 'CategoryName-chaiLatte', 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90'),
(1, 'CategoryName-icedCoffees', 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1'),
(1, 'CategoryName-ortea', 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90'),
(1, 'CategoryName-homemadeTea', 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90'),
(1, 'CategoryName-extras', 'api/image/cd62b21b-3400-4cc3-b4a5-0e6450e35852'),
(1, 'CategoryName-softDrinks', 'api/image/945a6a3a-9b6b-4a62-aaf7-62e9417c1217'),
(1, 'CategoryName-beerWineCocktails', 'api/image/23181078-defc-4d4d-beb0-1ad96c6683cc'),
(1, 'CategoryName-mocktails', 'api/image/96d0e484-1e99-4ff9-b8c9-d941d7a5220c');

-- =====================================================
-- Insert products
-- =====================================================
-- Koffies / Coffees (prices in euros)
INSERT INTO products (title_key, description_key, price, btw, stock, is_available, img_url, category_id)
VALUES
('ProductTitle-espresso', 'ProductDescription-espresso', 3.0, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffee')),
('ProductTitle-koffie', 'ProductDescription-koffie', 3.3, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffee')),
('ProductTitle-doppio', 'ProductDescription-doppio', 3.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffee')),
('ProductTitle-amerikano', 'ProductDescription-amerikano', 3.8, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffee')),

-- Koffies met melk
('ProductTitle-cortado', 'ProductDescription-cortado', 3.3, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffeeWithMilk')),
('ProductTitle-cappuccino', 'ProductDescription-cappuccino', 3.8, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffeeWithMilk')),
('ProductTitle-latte', 'ProductDescription-latte', 4.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffeeWithMilk')),
('ProductTitle-flatWhite', 'ProductDescription-flatWhite', 4.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-coffeeWithMilk')),

-- Speciale koffies
('ProductTitle-conPanna', 'ProductDescription-conPanna', 4.6, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-specialCoffee')),
('ProductTitle-hotAndSpiced', 'ProductDescription-hotAndSpiced', 4.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-specialCoffee')),
('ProductTitle-chococcino', 'ProductDescription-chococcino', 4.6, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-specialCoffee')),
('ProductTitle-mokka', 'ProductDescription-mokka', 4.8, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-specialCoffee')),
('ProductTitle-gemberccino', 'ProductDescription-gemberccino', 4.8, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-specialCoffee')),
('ProductTitle-latteSlagroom', 'ProductDescription-latteSlagroom', 5.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-specialCoffee')),

-- Warme chocomelk
('ProductTitle-swirlyHotChocolate', 'ProductDescription-swirlyHotChocolate', 3.8, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-hotChocolate')),
('ProductTitle-chocoladeboontjes', 'ProductDescription-chocoladeboontjes', 4.8, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-hotChocolate')),

-- Chai latte
('ProductTitle-chaiLatte', 'ProductDescription-chaiLatte', 4.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-chaiLatte')),
('ProductTitle-dirtyChai', 'ProductDescription-dirtyChai', 5.8, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-chaiLatte')),
('ProductTitle-matchaLatte', 'ProductDescription-matchaLatte', 6.0, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-chaiLatte')),

-- Iced koffies
('ProductTitle-icedLatte', 'ProductDescription-icedLatte', 5.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-icedCoffees')),
('ProductTitle-icedLongBlack', 'ProductDescription-icedLongBlack', 4.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-icedCoffees')),
('ProductTitle-icedChaiLatte', 'ProductDescription-icedChaiLatte', 5.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-icedCoffees')),
('ProductTitle-icedMatcha', 'ProductDescription-icedMatcha', 6.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-icedCoffees')),

-- Tea
('ProductTitle-tiffanysBreakfast', 'ProductDescription-tiffanysBreakfast', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),
('ProductTitle-dukesBlue', 'ProductDescription-dukesBlue', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),
('ProductTitle-mountFeather', 'ProductDescription-mountFeather', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),
('ProductTitle-lycheeWhitePeony', 'ProductDescription-lycheeWhitePeony', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),
('ProductTitle-beCamomile', 'ProductDescription-beCamomile', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),
('ProductTitle-laVieEnRose', 'ProductDescription-laVieEnRose', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),
('ProductTitle-kungFuFighter', 'ProductDescription-kungFuFighter', 3.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-ortea')),

-- Huisgemaakte thee
('ProductTitle-karkadeh', 'ProductDescription-karkadeh', 4.5, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-homemadeTea')),
('ProductTitle-verseMunt', 'ProductDescription-verseMunt', 5.0, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-homemadeTea')),
('ProductTitle-verseGember', 'ProductDescription-verseGember', 5.0, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-homemadeTea')),
('ProductTitle-yuzuThee', 'ProductDescription-yuzuThee', 5.0, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-homemadeTea')),
('ProductTitle-passievruchtThee', 'ProductDescription-passievruchtThee', 5.0, 21, 100, true, 'api/image/2a52beec-0f18-4278-b6a3-c5a9dc0b0f90', (SELECT id FROM product_categories WHERE name_key='CategoryName-homemadeTea')),

-- Extra's
('ProductTitle-smaaksiropen', 'ProductDescription-smaaksiropen', 0.6, 21, 100, true, 'api/image/cad8c522-4c00-43fe-ab38-d22a0727ae7c', (SELECT id FROM product_categories WHERE name_key='CategoryName-extras')),
('ProductTitle-honing', 'ProductDescription-honing', 0.6, 21, 100, true, 'api/image/07e67c5c-ba32-42e1-9ced-09b1e1266ee9', (SELECT id FROM product_categories WHERE name_key='CategoryName-extras')),
('ProductTitle-havermelk', 'ProductDescription-havermelk', 0.6, 21, 100, true, 'api/image/cd62b21b-3400-4cc3-b4a5-0e6450e35852', (SELECT id FROM product_categories WHERE name_key='CategoryName-extras')),
('ProductTitle-slagroom', 'ProductDescription-slagroom', 1.5, 21, 100, true, 'api/image/7607d020-8344-4a21-8afc-fb7c3a0b1e90', (SELECT id FROM product_categories WHERE name_key='CategoryName-extras')),
('ProductTitle-espressoShot', 'ProductDescription-espressoShot', 1.5, 21, 100, true, 'api/image/45842ac3-02cb-4960-b72b-c6998a329be1', (SELECT id FROM product_categories WHERE name_key='CategoryName-extras')),

-- Frisdranken & limonades & sappen
('ProductTitle-water', 'ProductDescription-water', 3.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-cola', 'ProductDescription-cola', 3.3, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-tonic', 'ProductDescription-tonic', 3.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-vruchtensapStandaard', 'ProductDescription-vruchtensapStandaard', 3.3, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-appelKersVruchtensap', 'ProductDescription-appelKersVruchtensap', 3.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-fentimans', 'ProductDescription-fentimans', 4.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-ritchiesLimo', 'ProductDescription-ritchiesLimo', 4.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-gemberCitroenLimo', 'ProductDescription-gemberCitroenLimo', 4.8, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),
('ProductTitle-iceTea', 'ProductDescription-iceTea', 4.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-softDrinks')),

-- Bier, wijn & cocktails
('ProductTitle-pintje', 'ProductDescription-pintje', 3.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-bast', 'ProductDescription-bast', 4.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-zwaardereBieren', 'ProductDescription-zwaardereBieren', 4.8, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-liefmans0', 'ProductDescription-liefmans0', 3.8, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-wijn', 'ProductDescription-wijn', 5.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-cava', 'ProductDescription-cava', 6.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-belliniMartini', 'ProductDescription-belliniMartini', 10.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-hugo', 'ProductDescription-hugo', 10.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-aperol', 'ProductDescription-aperol', 10.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-mojito', 'ProductDescription-mojito', 12.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),
('ProductTitle-ginTonic', 'ProductDescription-ginTonic', 12.5, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-beerWineCocktails')),

-- Mocktails
('ProductTitle-yellowSunrise', 'ProductDescription-yellowSunrise', 8.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-mocktails')),
('ProductTitle-redSunset', 'ProductDescription-redSunset', 8.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-mocktails')),
('ProductTitle-virginMojito', 'ProductDescription-virginMojito', 8.0, 21, 100, true, '', (SELECT id FROM product_categories WHERE name_key='CategoryName-mocktails'));




-- =========================================================
-- INSERT PRODUCT STEPS
-- =========================================================

INSERT INTO product_steps(title_key, product_id, default_option_id, multiple_choice)
VALUES
('ProductStep-coffee-extras', (SELECT id FROM products WHERE title_key='ProductTitle-koffie'), NULL, TRUE);

INSERT INTO product_step_options(product_step_id, product_id)
VALUES
((SELECT id FROM product_steps WHERE title_key='ProductStep-coffee-extras'), (SELECT id FROM products WHERE title_key='ProductTitle-slagroom')),
((SELECT id FROM product_steps WHERE title_key='ProductStep-coffee-extras'), (SELECT id FROM products WHERE title_key='ProductTitle-honing')),
((SELECT id FROM product_steps WHERE title_key='ProductStep-coffee-extras'), (SELECT id FROM products WHERE title_key='ProductTitle-havermelk')),
((SELECT id FROM product_steps WHERE title_key='ProductStep-coffee-extras'), (SELECT id FROM products WHERE title_key='ProductTitle-espressoShot')),
((SELECT id FROM product_steps WHERE title_key='ProductStep-coffee-extras'), (SELECT id FROM products WHERE title_key='ProductTitle-smaaksiropen'));


COMMIT
