# Library Management System (LMS)

A robust and efficient web-based Library Management System built using ASP.NET Core Razor Pages and MySQL. This project provides a complete CRUD (Create, Read, Update, Delete) interface for managing library book inventories.

## 🚀 Workflow of the Project

1.  **Database Setup**: The system relies on a MySQL backend. The workflow begins by executing the `db.sql` script to create the `library_db` database and the `books` table.
2.  **Configuration**: The application connects to the MySQL server using a connection string defined in the code-behind (`.cshtml.cs`) files.
3.  **Book Management**:
    *   **Inventory View**: The home screen lists all available books in a structured table.
    *   **Searching**: Users can search for books in real-time by title, author, or category using the search bar.
    *   **Adding Books**: A dedicated form allows librarians to input book details (Title, Author, ISBN, etc.).
    *   **Updating**: Existing records can be modified to reflect changes in quantity, price, or details.
    *   **Deletion**: Books can be removed from the system after a security confirmation step.

## 💡 Concepts Used

### 1. ASP.NET Core Razor Pages
Used for building the web application structure. It simplifies the development of page-focused scenarios by grouping the HTML (`.cshtml`) and logic (`.cshtml.cs`) together.

### 2. ADO.NET (MySql.Data)
Direct interaction with the MySQL database is performed using the `MySql.Data` library. This includes:
-   **MySqlConnection**: Establishing connections to the database.
-   **MySqlCommand**: Executing SQL queries.
-   **MySqlDataReader**: Reading data streams from the database efficiently.

### 3. Model-View Pattern
The project maintains a clear separation of concerns:
-   **Models**: The `BookInfo` class defines the data structure.
-   **Pages (Views/Logic)**: The Razor Pages handle both the presentation and the request processing.

### 4. SQL CRUD Operations
Implementation of fundamental database operations:
-   `INSERT` for creating new records.
-   `SELECT` (with `LIKE` filters) for reading and searching.
-   `UPDATE` for modifying data.
-   `DELETE` for removing records.

### 5. Security - SQL Injection Prevention
All database queries use **parameterized queries** (e.g., `@id`, `@title`). This is a critical security concept that prevents attackers from injecting malicious SQL code into the system.

### 6. Bootstrap Framework
Used for styling the user interface. It provides a "Premium" look and feel with responsive tables, buttons, and alert components.

### 7. Data Binding
Utilizes the `[BindProperty]` attribute to automatically map form data from HTTP requests to C# objects, reducing manual parsing code.

---

## 🛠️ Prerequisites
-   .NET 8.0 SDK or later
-   MySQL Server
-   Visual Studio / VS Code
