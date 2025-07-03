CREATE DATABASE dairy_db;
USE dairy_db;
CREATE TABLE DairyProducts (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Type VARCHAR(100),
    Category VARCHAR(100),
    ShelfLife VARCHAR(50),
    Supplier VARCHAR(100),
    Name VARCHAR(100),
    Price DECIMAL(10, 2)
);

USE dairy_db;

INSERT INTO DairyProducts (Type, Category, ShelfLife, Supplier, Name, Price) VALUES
('Молоко', 'Пастеризоване', '10 днів', 'Ферма1', 'Молоко 2.5%', 25.50),
('Сир', 'Твердий', '60 днів', 'Молокозавод', 'Сир Гауда', 150.00),
('Йогурт', 'Натуральний', '14 днів', 'Данон', 'Йогурт без цукру', 35.75),
('Вершкове масло', 'Солоне', '30 днів', 'Ферма2', 'Масло 82%', 120.30),
('Кефір', 'Класичний', '7 днів', 'Лакталіс', 'Кефір 1%', 20.00);

INSERT INTO DairyProducts (Type, Category, ShelfLife, Supplier, Name, Price) VALUES
('Сметана', 'Жирна', '15 днів', 'Ферма1', 'Сметана 20%', 45.90),
('Творог', 'Знежирений', '10 днів', 'Молокозавод', 'Творог 0%', 60.25),
('Ряженка', 'Традиційна', '12 днів', 'Данон', 'Ряженка 2.5%', 28.50);