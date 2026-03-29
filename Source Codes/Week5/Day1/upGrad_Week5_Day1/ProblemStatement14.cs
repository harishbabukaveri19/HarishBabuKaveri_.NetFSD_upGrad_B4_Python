// 14.Write a LINQ query to display whether all products are below Mrp Rs.30 or not.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement14
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to check condition
            bool allBelow30 = products.All(prod => prod.ProMrp < 30);

            // Display result
            if (allBelow30)
                Console.WriteLine("All products are below Rs.30");
            else
                Console.WriteLine("Not all products are below Rs.30");
        }
    }
}