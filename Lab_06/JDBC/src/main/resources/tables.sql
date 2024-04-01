CREATE TABLE Manufacturers (
    manufacturer_id NUMBER PRIMARY KEY,
    name VARCHAR(255),
    country VARCHAR(255)
);

CREATE TABLE Watches (
    watch_id NUMBER PRIMARY KEY,
    brand VARCHAR(255),
    type VARCHAR(255),
    price NUMBER,
    quantity NUMBER,
    manufacturer_id NUMBER,
    FOREIGN KEY (manufacturer_id) REFERENCES Manufacturers(manufacturer_id)
);
-- Вставка данных в таблицу Manufacturers
INSERT INTO Manufacturers (manufacturer_id, name, country)
VALUES (1, 'Manufacturer1', 'Country1');

INSERT INTO Manufacturers (manufacturer_id, name, country)
VALUES (2, 'Manufacturer2', 'Country2');

-- Вставка данных в таблицу Watches
INSERT INTO Watches (watch_id, brand, type, price, quantity, manufacturer_id)
VALUES (1, 'Brand1', 'Mechanical', 100.00, 10, 1);
INSERT INTO Watches (watch_id, brand, type, price, quantity, manufacturer_id)
VALUES (3, 'Rolex', 'Mechanical', 10.00, 10, 1);

INSERT INTO Watches (watch_id, brand, type, price, quantity, manufacturer_id)
VALUES (2, 'Brand2', 'Quartz', 50.00, 5, 2);

INSERT INTO Watches (watch_id, brand, type, price, quantity, manufacturer_id)
VALUES (5, 'Casio', 'Quartz', 950.00, 5, 1);
commit;
