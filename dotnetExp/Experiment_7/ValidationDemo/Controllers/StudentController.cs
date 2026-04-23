using Microsoft.AspNetCore.Mvc;
using ValidationDemo.Models;

public class StudentController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if(ModelState.IsValid)
        {
            return Content("Form Submitted Successfully");
        }

        return View(student);
    }
}
