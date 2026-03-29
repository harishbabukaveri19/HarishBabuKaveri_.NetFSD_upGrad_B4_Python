// 13.Write a LINQ query to display Min price.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement13
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to get maximum price
            double minPrice = products.Min(prod => prod.ProMrp);

            // Display result
            Console.WriteLine($"Minimum Price: {minPrice}");
        }
    }
}
