// 11.Write a LINQ query to display count of total products with category FMCG.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement11
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to count FMCG products
            int fmcgCount = products.Count(prod => prod.ProCategory == "FMCG");

            // Display result
            Console.WriteLine($"Total FMCG products: {fmcgCount}");
        }
    }
}