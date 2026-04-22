using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Models;


namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updateProduct)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            product.Category = updateProduct.Category;
            product.Stock = updateProduct.Stock;

            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
