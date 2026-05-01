using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using LibraryProject.Models;

namespace LibraryProject.Pages.Books
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BookInfo bookInfo { get; set; } = new BookInfo();

        public string errorMessage = "";
        public string successMessage = "";

        private string connectionString = "Server=localhost; Port=3306; Database=library_db; Uid=root; Pwd=manager;";

        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM books WHERE id=@id";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bookInfo.Id = reader.GetInt32(0);
                                bookInfo.Title = reader.GetString(1);
                                bookInfo.Author = reader.GetString(2);
                                bookInfo.ISBN = reader.GetString(3);
                                bookInfo.Category = reader.GetString(4);
                                bookInfo.Quantity = reader.GetInt32(5);
                                bookInfo.Price = reader.GetDecimal(6);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
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
                    string sql = "UPDATE books SET title=@title, author=@author, isbn=@isbn, category=@category, quantity=@quantity, price=@price WHERE id=@id";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@title", bookInfo.Title);
                        command.Parameters.AddWithValue("@author", bookInfo.Author);
                        command.Parameters.AddWithValue("@isbn", bookInfo.ISBN);
                        command.Parameters.AddWithValue("@category", bookInfo.Category);
                        command.Parameters.AddWithValue("@quantity", bookInfo.Quantity);
                        command.Parameters.AddWithValue("@price", bookInfo.Price);
                        command.Parameters.AddWithValue("@id", bookInfo.Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Books/Index");
        }
    }
}
