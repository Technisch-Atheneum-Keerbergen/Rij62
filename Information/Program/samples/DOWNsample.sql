BEGIN;

-- Remove dependent data first
DELETE FROM order_items;
DELETE FROM orders;

DELETE FROM product_available_history;
DELETE FROM products;

DELETE FROM product_categories;
DELETE FROM screens;

DELETE FROM tables;
DELETE FROM users;

DELETE FROM language;

COMMIT;