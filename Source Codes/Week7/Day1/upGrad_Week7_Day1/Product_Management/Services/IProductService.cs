using Product_Management.Models;
using System.Collections.Generic;

namespace Product_Management.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void DeleteProduct(int id);
    }
}