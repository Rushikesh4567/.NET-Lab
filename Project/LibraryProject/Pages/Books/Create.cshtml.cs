using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using LibraryProject.Models;

namespace LibraryProject.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BookInfo bookInfo { get; set; } = new BookInfo();

        public string errorMessage = "";
        public string successMessage = "";

        private string connectionString = "Server=localhost; Port=3306; Database=library_db; Uid=root; Pwd=manager;";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (string.IsNullOrEmpty(bookInfo.Title) || string.IsNullOrEmpty(bookInfo.Author) || 
                string.IsNullOrEmpty(bookInfo.ISBN) || string.IsNullOrEmpty(bookInfo.Category))
            {
                errorMessage = "All fields are required";
                return;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO books (title, author, isbn, category, quantity, price) " +
                                 "VALUES (@title, @author, @isbn, @category, @quantity, @price)";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@title", bookInfo.Title);
                        command.Parameters.AddWithValue("@author", bookInfo.Author);
                        command.Parameters.AddWithValue("@isbn", bookInfo.ISBN);
                        command.Parameters.AddWithValue("@category", bookInfo.Category);
                        command.Parameters.AddWithValue("@quantity", bookInfo.Quantity);
                        command.Parameters.AddWithValue("@price", bookInfo.Price);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            bookInfo.Title = "";
            bookInfo.Author = "";
            bookInfo.ISBN = "";
            bookInfo.Category = "";
            bookInfo.Quantity = 0;
            bookInfo.Price = 0;
            successMessage = "New Book Added Correctly";

            Response.Redirect("/Books/Index");
        }
    }
}
