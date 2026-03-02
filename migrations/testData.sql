BEGIN;

-- =========================
-- SCREENS
-- =========================
INSERT INTO screens (name) VALUES
('Drinks'),
('Food'),
('Desserts'),
('Specials');

-- =========================
-- TABLES (restaurant tables)
-- =========================
INSERT INTO tables (table_number) VALUES
(1),(2),(3),(4),(5),(6),(7),(8),(9),(10);

-- =========================
-- USERS
-- =========================
INSERT INTO users (username,password,email) VALUES
('admin', 'password','admin@restaurant.com'),
('staff1','password','staff1@restaurant.com'),
('staff2','password','staff2@restaurant.com');

-- =========================
-- CATEGORIES
-- =========================
INSERT INTO product_categories (name, screen_id) VALUES
('Soft Drinks',1),
('Beers',1),
('Cocktails',1),
('Burgers',2),
('Pasta',2),
('Salads',2),
('Snacks',2),
('Ice Cream',3),
('Cakes',3),
('Limited Edition',4);

-- =========================
-- PRODUCTS (60 TOTAL)
-- =========================
INSERT INTO products
(title_key,description_key,price_cent,stock,is_available,img_url,category_id)
VALUES

-- Soft Drinks
('cola_title','cola_desc',250,200,true,'/img/cola.jpg',1),
('fanta_title','fanta_desc',250,200,true,'/img/fanta.jpg',1),
('sprite_title','sprite_desc',250,200,true,'/img/sprite.jpg',1),
('water_title','water_desc',200,300,true,'/img/water.jpg',1),
('ice_tea_title','ice_tea_desc',280,150,true,'/img/icetea.jpg',1),
('redbull_title','redbull_desc',350,100,true,'/img/redbull.jpg',1),

-- Beers
('jupiler_title','jupiler_desc',300,120,true,'/img/jupiler.jpg',2),
('duvel_title','duvel_desc',450,80,true,'/img/duvel.jpg',2),
('leffe_title','leffe_desc',400,90,true,'/img/leffe.jpg',2),
('hoegaarden_title','hoegaarden_desc',380,70,true,'/img/hoegaarden.jpg',2),
('corona_title','corona_desc',500,60,true,'/img/corona.jpg',2),
('tripel_title','tripel_desc',480,75,true,'/img/tripel.jpg',2),

-- Cocktails
('mojito_title','mojito_desc',900,40,true,'/img/mojito.jpg',3),
('pina_title','pina_desc',950,35,true,'/img/pina.jpg',3),
('martini_title','martini_desc',1100,30,true,'/img/martini.jpg',3),
('gin_title','gin_desc',850,50,true,'/img/gin.jpg',3),
('negroni_title','negroni_desc',950,40,true,'/img/negroni.jpg',3),
('whiskey_sour_title','whiskey_sour_desc',1000,35,true,'/img/ws.jpg',3),

-- Burgers
('classic_title','classic_desc',1250,60,true,'/img/classic.jpg',4),
('cheese_title','cheese_desc',1350,50,true,'/img/cheese.jpg',4),
('bacon_title','bacon_desc',1450,45,true,'/img/bacon.jpg',4),
('double_title','double_desc',1650,40,true,'/img/double.jpg',4),
('veggie_title','veggie_desc',1300,35,true,'/img/veggie.jpg',4),
('bbq_title','bbq_desc',1550,30,true,'/img/bbq.jpg',4),

-- Pasta
('carbonara_title','carbonara_desc',1400,50,true,'/img/carbonara.jpg',5),
('bolognese_title','bolognese_desc',1450,50,true,'/img/bolognese.jpg',5),
('pesto_title','pesto_desc',1350,45,true,'/img/pesto.jpg',5),
('lasagna_title','lasagna_desc',1500,40,true,'/img/lasagna.jpg',5),
('seafood_title','seafood_desc',1750,30,true,'/img/seafood.jpg',5),
('truffle_pasta_title','truffle_pasta_desc',1900,25,true,'/img/trufflepasta.jpg',5),

-- Salads
('caesar_title','caesar_desc',1100,40,true,'/img/caesar.jpg',6),
('greek_title','greek_desc',1000,35,true,'/img/greek.jpg',6),
('chicken_salad_title','chicken_salad_desc',1200,35,true,'/img/chicken.jpg',6),
('tuna_title','tuna_desc',1150,30,true,'/img/tuna.jpg',6),
('quinoa_title','quinoa_desc',1050,30,true,'/img/quinoa.jpg',6),
('avocado_title','avocado_desc',1250,25,true,'/img/avocado.jpg',6),

-- Snacks
('fries_title','fries_desc',450,200,true,'/img/fries.jpg',7),
('loaded_title','loaded_desc',750,100,true,'/img/loaded.jpg',7),
('wings_title','wings_desc',950,80,true,'/img/wings.jpg',7),
('nachos_title','nachos_desc',850,90,true,'/img/nachos.jpg',7),
('mozza_title','mozza_desc',800,100,true,'/img/mozza.jpg',7),
('onion_title','onion_desc',700,110,true,'/img/onion.jpg',7),

-- Ice Cream
('vanilla_title','vanilla_desc',600,70,true,'/img/vanilla.jpg',8),
('choco_title','choco_desc',600,70,true,'/img/choco.jpg',8),
('strawberry_title','strawberry_desc',600,70,true,'/img/strawberry.jpg',8),
('cookie_title','cookie_desc',650,60,true,'/img/cookie.jpg',8),
('banana_title','banana_desc',900,40,true,'/img/banana.jpg',8),
('oreo_title','oreo_desc',700,50,true,'/img/oreo.jpg',8),

-- Cakes
('cheesecake_title','cheesecake_desc',750,30,true,'/img/cheesecake.jpg',9),
('brownie_title','brownie_desc',650,40,true,'/img/brownie.jpg',9),
('tiramisu_title','tiramisu_desc',800,35,true,'/img/tiramisu.jpg',9),
('apple_title','apple_desc',700,30,true,'/img/apple.jpg',9),
('lava_title','lava_desc',850,25,true,'/img/lava.jpg',9),
('carrot_title','carrot_desc',750,20,true,'/img/carrot.jpg',9),

-- Specials
('wagyu_title','wagyu_desc',3500,10,true,'/img/wagyu.jpg',10),
('lobster_title','lobster_desc',2400,15,true,'/img/lobster.jpg',10),
('gold_title','gold_desc',5000,5,true,'/img/gold.jpg',10),
('truffle_burger_title','truffle_burger_desc',1900,20,true,'/img/truffleb.jpg',10),
('chef_special_title','chef_special_desc',2100,15,true,'/img/chef.jpg',10),
('limited_cocktail_title','limited_cocktail_desc',1800,20,true,'/img/limited.jpg',10);

-- =========================
-- LANGUAGE (example subset)
-- =========================
INSERT INTO language (key,lang,value) VALUES
('cola_title',0,'Coca Cola'),
('cola_desc',0,'Refreshing Coca Cola 33cl'),
('cola_title',1,'Coca Cola'),
('cola_desc',1,'Verfrissende Coca Cola 33cl'),
('classic_title',0,'Classic Burger'),
('classic_desc',0,'Beef burger with lettuce & tomato'),
('classic_title',1,'Klassieke Burger'),
('classic_desc',1,'Rundsvlees burger met sla & tomaat');

-- =========================
-- AVAILABILITY (happy hour cocktails 17:00-19:00)
-- =========================
INSERT INTO product_available_history (product_id,start_time,end_time) VALUES
(13,1700,1900),
(14,1700,1900),
(15,1700,1900);

-- =========================
-- ORDERS
-- =========================
INSERT INTO orders (table_id,pickup_time,status) VALUES
(1,1730,1),
(3,1800,1),
(NULL,1815,2);

-- =========================
-- ORDER ITEMS
-- =========================
INSERT INTO order_items (product_id,order_id,title,price_cent,table_number) VALUES
(1,1,'Coca Cola',250,1),
(19,1,'Classic Burger',1250,1),
(42,2,'Brownie',650,3),
(13,2,'Mojito',900,3),
(55,3,'Wagyu Steak',3500,0);

COMMIT;