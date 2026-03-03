CREATE TABLE language (
  key VARCHAR NOT NULL,
  lang INTEGER NOT NULL,
  value VARCHAR NOT NULL
);

CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  username VARCHAR NOT NULL,
  password VARCHAR NOT NULL,
  email VARCHAR NOT NULL
);
CREATE TABLE tables (
  id SERIAL PRIMARY KEY,
  table_number INTEGER UNIQUE NOT NULL
);

CREATE TABLE screens (
  id SERIAL PRIMARY KEY,
  Description VARCHAR NOT NULL,
  name VARCHAR NOT NULL
);

CREATE TABLE product_categories (
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL,
  screen_id INTEGER NULL,
  FOREIGN KEY (screen_id) REFERENCES screens(id) ON DELETE SET NULL
);

CREATE TABLE products (
  id SERIAL PRIMARY KEY,
  title_key VARCHAR NOT NULL,
  description_key VARCHAR NOT NULL,
  price_cent INTEGER NOT NULL,
  stock INTEGER NOT NULL,
  is_available BOOLEAN NOT NULL,
  img_url VARCHAR NULL,
  category_id INTEGER NOT NULL,
  FOREIGN KEY (category_id) REFERENCES product_categories(id) ON DELETE RESTRICT
);

CREATE TABLE product_available_history (
  product_id INTEGER NOT NULL,
  start_time INTEGER,
  end_time INTEGER,
  FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE
);

CREATE TABLE orders (
  id SERIAL PRIMARY KEY,
  table_id INTEGER NULL,
  pickup_time INTEGER NOT NULL,
  status INTEGER NOT NULL,
  FOREIGN KEY (table_id) REFERENCES tables(id) ON DELETE RESTRICT
);

CREATE TABLE order_items (
  product_id INTEGER NULL,
  order_id INTEGER NULL,
  title VARCHAR NOT NULL,
  price_cent INTEGER NOT NULL,
  table_number INTEGER NOT NULL,
  FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE SET NULL,
  FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE SET NULL
);