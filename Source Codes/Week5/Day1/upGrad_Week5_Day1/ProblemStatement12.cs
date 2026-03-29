// 12.Write a LINQ query to display Max price.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement12
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to get maximum price
            double maxPrice = products.Max(prod => prod.ProMrp);

            // Display result
            Console.WriteLine($"Maximum Price: {maxPrice}");
        }
    }
}