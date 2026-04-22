using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        // Static list to store products (in-memory)
        private static List<dynamic> products = new List<dynamic>();

        // GET: product/index
        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

        // POST: product/add
        [HttpPost("add")]
        public IActionResult Add(string name, double price, int quantity)
        {
            var product = new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            products.Add(product);

            ViewBag.Products = products;

            return View("Index");
        }
    }
}