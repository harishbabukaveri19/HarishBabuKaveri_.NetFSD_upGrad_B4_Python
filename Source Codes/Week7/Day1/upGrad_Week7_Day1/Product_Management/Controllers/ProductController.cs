using Microsoft.AspNetCore.Mvc;
using Product_Management.Models;
using Product_Management.Services;

namespace Product_Management.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        // Constructor Injection
        public ProductController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var products = _service.GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _service.GetProductById(id);
            return View(product);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _service.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}