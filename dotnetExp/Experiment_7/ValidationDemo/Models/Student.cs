using System.ComponentModel.DataAnnotations;

namespace ValidationDemo.Models
{
    public class Student
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage ="Enter valid email")]
    public string Email { get; set; }

    [Range(18, 60, ErrorMessage ="Age must be between 18 and 60")]
    public int Age { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 6)]
    public string Password { get; set; }
}
}


