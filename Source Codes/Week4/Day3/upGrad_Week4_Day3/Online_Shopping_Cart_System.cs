//Level - 2 Problem 4: Online Shopping Cart System
//Scenario:
//An e-commerce platform needs a flexible cart system where different product types calculate discounts differently.
//Requirements:
//1.Create a base class Product with properties Name and Price.
//2. Create derived classes Electronics and Clothing.
//3. Implement a virtual method CalculateDiscount().
//4. Electronics get 5% discount, Clothing gets 15% discount.
//5. Use encapsulation to protect price updates.
//Technical Constraints:
//• Use private fields with public properties.
//• Apply inheritance and method overriding.
//• Prevent negative price assignment.
//Expectations:
//• Demonstrate polymorphic behavior in cart processing.
//• Apply data validation inside properties.
//• Calculate and display final price after discount.
//Learning Outcome:
//• Combine encapsulation and polymorphism.
//• Design extensible product hierarchy.
//• Implement business logic in overridden methods.
//Sample Input: Electronics Price = 20000
//Sample Output: Final Price after 5% discount = 19000


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day3
{
    internal class Online_Shopping_Cart_System
    {
        class Product
        {
            public string Name { get; set; }

            private double price;

            public double Price
            {
                get { return price; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Price cannot be negative. Setting to 0.");
                        price = 0;
                    }
                    else
                    {
                        price = value;
                    }
                }
            }

            public virtual double CalculateDiscount()
            {
                return Price;
            }
        }

        class Electronics : Product
        {
            public override double CalculateDiscount()
            {
                return Price - (0.05 * Price);
            }
        }

        class Clothing : Product
        {
            public override double CalculateDiscount()
            {
                return Price - (0.15 * Price);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter product type (Electronics/Clothing): ");
                string type = Console.ReadLine();   

                Console.Write("Enter price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                Product product;

                // Polymorphism
                if (type.ToLower() == "electronics")
                {
                    product = new Electronics();
                }
                else
                {
                    product = new Clothing();
                }

                product.Price = price;

                double finalPrice = product.CalculateDiscount();

                Console.WriteLine("Final Price after discount = " + finalPrice);
            }
        }
    }
}
