// 15.Write a LINQ query to display whether any products are below Mrp Rs.30 or not.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement15
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to check if any product is below Rs.30
            bool anyBelow30 = products.Any(prod => prod.ProMrp < 30);

            // Display result
            if (anyBelow30)
                Console.WriteLine("There are products below Rs.30");
            else
                Console.WriteLine("No products are below Rs.30");
        }
    }
}