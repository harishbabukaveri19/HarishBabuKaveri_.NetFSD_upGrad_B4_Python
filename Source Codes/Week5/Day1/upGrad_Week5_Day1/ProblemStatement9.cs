// 9.Write a LINQ query to display product detail with highest price in FMCG category.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day1
{
    internal class ProblemStatement9
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // LINQ query: Filter FMCG + get highest price
            var highestFMCG = products
                                .Where(prod => prod.ProCategory == "FMCG")
                                .OrderByDescending(prod => prod.ProMrp)
                                .FirstOrDefault();

            // Display result
            if (highestFMCG != null)
            {
                Console.WriteLine($"{highestFMCG.ProCode} - {highestFMCG.ProName} - {highestFMCG.ProCategory} - {highestFMCG.ProMrp}");
            }
        }
    }
}