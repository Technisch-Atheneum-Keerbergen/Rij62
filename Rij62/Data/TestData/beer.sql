BEGIN;

-- ============================================
-- Product: Tripel D'Anvers
-- ============================================

-- 1. Insert product
INSERT INTO products (
    title_key,
    description_key,
    price_cent,
    btw,
    stock,
    is_available,
    img_url,
    category_id
)
VALUES (
    'ProductTitle-tripel-danvers-001',
    'ProductDescription-tripel-danvers-001',
    2, -- €2.00 -> 200 cents
    21,
    50,
    true,
    '/images/blueberries.jpg',
    0
);

-- 2. Insert translations
INSERT INTO language (key, language, value) VALUES

-- Title
('ProductTitle-tripel-danvers-001', 0, 'Tripel D''Anvers'),
('ProductTitle-tripel-danvers-001', 1, 'Tripel D''Anvers'),

-- Description
('ProductDescription-tripel-danvers-001', 0, 'Brouwerij De Coninck'),
('ProductDescription-tripel-danvers-001', 1, 'Brewery De Coninck');

COMMIT;