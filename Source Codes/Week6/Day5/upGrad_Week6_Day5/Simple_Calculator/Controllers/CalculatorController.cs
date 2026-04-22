using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        // GET: calculator/add
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        // POST: calculator/add
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            ViewData["Result"] = result;
            ViewData["Num1"] = num1;
            ViewData["Num2"] = num2;

            return View();
        }
    }
}