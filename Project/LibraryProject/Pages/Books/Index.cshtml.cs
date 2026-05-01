using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using LibraryProject.Models;

namespace LibraryProject.Pages.Books
{
    public class IndexModel : PageModel
    {
        public List<BookInfo> listBooks = new List<BookInfo>();
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        private string connectionString = "Server=localhost; Port=3306; Database=library_db; Uid=root; Pwd=manager;";

        public void OnGet()
        {
            try {
                using (var connection = new MySqlConnection(connectionString)) {
                    connection.Open();
                    
                    string sql = "SELECT * FROM books";
                    if (!string.IsNullOrEmpty(SearchTerm)) {
                        sql += " WHERE title LIKE @search OR author LIKE @search OR category LIKE @search";
                    }

                    using (var command = new MySqlCommand(sql, connection)) {
                        if (!string.IsNullOrEmpty(SearchTerm)) {
                            command.Parameters.AddWithValue("@search", "%" + SearchTerm + "%");
                        }

                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                listBooks.Add(new BookInfo {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Author = reader.GetString(2),
                                    ISBN = reader.GetString(3),
                                    Category = reader.GetString(4),
                                    Quantity = reader.GetInt32(5),
                                    Price = reader.GetDecimal(6)
                                });
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
