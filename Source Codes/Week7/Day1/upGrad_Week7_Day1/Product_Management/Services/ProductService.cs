using Product_Management.Models;
using Product_Management.Services;
using System.Collections.Generic;
using System.Linq;

namespace Product_Management.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 },
            new Product { Id = 2, Name = "Mobile", Price = 20000 }
        };

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                products.Remove(product);
        }
    }
}