-- Used to store order images.
CREATE TABLE images(
  id SERIAL PRIMARY KEY,
  data BYTEA
);

CREATE TABLE tables(
  id SERIAL PRIMARY KEY,
  table_number INTEGER UNIQUE NOT NULL
);

-- (virtual) Kitchens can be linked to product_categories.
-- One kitchen will be shown on each screen so the kitchen that prepares drinks can be on a separate screen from the one that prepares food.
CREATE TABLE kitchen(
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL
);

CREATE TABLE product_categories(
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL,

  -- A category always needs a kitchen because else it can never be prepared because it is not shown on any screen.
  kitchen_id INTEGER NOT NULL,

  FOREIGN KEY (kitchen_id) REFERENCES kitchen(id) ON DELETE RESTRICT -- Don't allow deletion of kitchens that still contain categories
);

CREATE TABLE products(
  id SERIAL PRIMARY KEY,
  title VARCHAR NOT NULL,
  description VARCHAR NOT NULL,
  price_cent INTEGER NOT NULL,
  is_availible BOOLEAN NOT NULL,

  img_id INTEGER NULL,
  -- category of order (drink, food,...) needs to exist because kitchens are linked to categories.
  category_id INTEGER NOT NULL,

  FOREIGN KEY (img_id) REFERENCES images(id) ON DELETE SET NULL, -- Don't delete products when an image is deleted
  FOREIGN KEY (category_id) REFERENCES product_categories(id) ON DELETE RESTRICT -- Don't allow deletion of categories that still contain products
);

CREATE TABLE orders(
  id SERIAL PRIMARY KEY,
  table_id INTEGER NULL, -- NULL on orders from outside the restaurant
  arival_time INTEGER NOT NULL, -- unix timestamp for when the order is wanted

  FOREIGN KEY (table_id) REFERENCES tables(id) ON DELETE CASCADE
);

CREATE TABLE product_order_links(
  product_id INTEGER NOT NULL,
  order_id INTEGER NOT NULL,

  FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE,
  FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE,
);

