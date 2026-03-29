using Microsoft.Extensions.Configuration;
using ProductApp.Data;
using ProductApp.Models;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        ProductDAL dal = new ProductDAL(config);

        while (true)
        {
            Console.WriteLine("\n--- PRODUCT MANAGEMENT ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Choose option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product p = new Product();

                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Price: ");
                    p.Price = Convert.ToDecimal(Console.ReadLine());

                    dal.InsertProduct(p);
                    Console.WriteLine("Product Added!");
                    break;

                case 2:

                    var products = dal.GetAllProducts();

                    if (!products.Any())
                    {
                        Console.WriteLine("No products found.");
                    }

                    Console.WriteLine("\n-----------------------------------------------");
                    Console.WriteLine($"{"ID",-5} {"Name",-20} {"Category",-15} {"Price",-10}");
                    Console.WriteLine("-----------------------------------------------");

                    foreach (var item in products)
                    {
                        Console.WriteLine($"{item.ProductId,-5} {item.ProductName,-20} {item.Category,-15} {item.Price,-10}");
                    }

                    Console.WriteLine("-----------------------------------------------");
                    break;

                case 3:
                    Product up = new Product();

                    Console.Write("Enter ID: ");
                    up.ProductId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("New Name: ");
                    up.ProductName = Console.ReadLine();

                    Console.Write("New Category: ");
                    up.Category = Console.ReadLine();

                    Console.Write("New Price: ");
                    up.Price = Convert.ToDecimal(Console.ReadLine());

                    dal.UpdateProduct(up);
                    Console.WriteLine("Updated!");
                    break;

                case 4:
                    Console.Write("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    dal.DeleteProduct(id);
                    Console.WriteLine("Deleted!");
                    break;

                case 5:
                    return;
            }
        }
    }
}