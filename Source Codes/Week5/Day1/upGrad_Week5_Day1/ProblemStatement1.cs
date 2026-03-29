// 1.Write a LINQ query to search and display all products with category “FMCG”.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            var result = products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
        }
    }
}