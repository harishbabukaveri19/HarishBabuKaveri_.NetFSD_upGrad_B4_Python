// 2.Write a LINQ query to search and display all products with category “Grain”.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement2
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.Where(p => p.ProCategory == "Grain").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
        }
    }
}