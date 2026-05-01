using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace LibraryProject.Pages.Books
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        private string connectionString = "Server=localhost; Port=3306; Database=library_db; Uid=root; Pwd=manager;";

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Id <= 0)
            {
                return RedirectToPage("/Books/Index");
            }

            try 
            {
                using (var connection = new MySqlConnection(connectionString)) 
                {
                    connection.Open();
                    string sql = "DELETE FROM books WHERE id=@id";
                    using (var command = new MySqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@id", Id);
                        command.ExecuteNonQuery();
                    }
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Error deleting book: " + ex.Message);
            }
            
            return RedirectToPage("/Books/Index");
        }
    }
}
