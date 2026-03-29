// 10.Write a LINQ query to display count of total products.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace upGrad_Week5_Day1
{
    internal class ProblemStatement10
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to count total products
            int totalCount = products.Count();

            // Display result
            Console.WriteLine($"Total number of products: {totalCount}");
        }
    }
}