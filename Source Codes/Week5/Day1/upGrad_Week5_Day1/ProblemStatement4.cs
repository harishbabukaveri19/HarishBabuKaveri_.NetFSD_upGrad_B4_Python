// 4.Write a LINQ query to sort products in ascending order by product Category.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement4
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to sort by ProCode (ascending)
            var sortedProducts = products.OrderBy(prod => prod.ProCategory);

            // Display output
            foreach (var item in sortedProducts)
            {
                Console.WriteLine($"{item.ProCode} - {item.ProName} - {item.ProCategory} - {item.ProMrp}");
            }
        }
    }
}