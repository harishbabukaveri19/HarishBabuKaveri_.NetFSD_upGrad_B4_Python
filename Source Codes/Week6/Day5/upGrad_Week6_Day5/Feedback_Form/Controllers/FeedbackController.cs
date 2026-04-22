using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        // GET: feedback/form
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        // POST: feedback/submit
        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            // Conditional logic
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank you for your valuable feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            ViewData["Name"] = name;
            ViewData["Rating"] = rating;

            return View("Form"); // return same page
        }
    }
}