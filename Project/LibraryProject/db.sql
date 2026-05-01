-- MySQL Database Schema for Library Management System

CREATE DATABASE IF NOT EXISTS library_db;
USE library_db;

CREATE TABLE IF NOT EXISTS books (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255) NOT NULL,
    isbn VARCHAR(20) NOT NULL,
    category VARCHAR(100) NOT NULL,
    quantity INT NOT NULL DEFAULT 0,
    price DECIMAL(10, 2) NOT NULL
);

-- Sample Data
INSERT INTO books (title, author, isbn, category, quantity, price) VALUES
('The Great Gatsby', 'F. Scott Fitzgerald', '978-0743273565', 'Classic', 10, 15.99),
('To Kill a Mockingbird', 'Harper Lee', '978-0061120084', 'Fiction', 5, 12.50),
('1984', 'George Orwell', '978-0451524935', 'Dystopian', 8, 10.99),
('The Catcher in the Rye', 'J.D. Salinger', '978-0316769488', 'Classic', 12, 14.00);
