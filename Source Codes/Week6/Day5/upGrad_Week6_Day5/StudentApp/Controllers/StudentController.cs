using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            // DEBUG CHECK
            Console.WriteLine($"Name: {name}, Age: {age}, Course: {course}");

            TempData["Name"] = name;
            TempData["Age"] = age;
            TempData["Course"] = course;

            return RedirectToAction("Display");
        }

        [HttpGet("display")]
        public IActionResult Display()
        {
            return View();
        }
    }
}