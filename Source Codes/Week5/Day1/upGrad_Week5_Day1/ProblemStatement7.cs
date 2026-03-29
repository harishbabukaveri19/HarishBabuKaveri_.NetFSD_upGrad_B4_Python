// 7.Write a LINQ query to display products group by product Category.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement7
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query to group by category
            var groupedProducts = products.GroupBy(prod => prod.ProCategory);

            // Display output
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"Category: {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($"   {item.ProCode} - {item.ProName} - {item.ProMrp}");
                }

                Console.WriteLine();
            }
        }
    }
}