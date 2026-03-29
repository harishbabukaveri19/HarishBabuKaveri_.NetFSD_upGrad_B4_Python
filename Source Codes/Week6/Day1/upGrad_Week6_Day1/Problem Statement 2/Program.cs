//Problem: 2 - OCP – Open Closed Principle
//Scenario: Discount Calculation System
//An e-commerce system calculates discounts for different customer types:
//•	Regular Customer
//•	Premium Customer
//•	VIP Customer
//The system should allow adding new discount types without modifying existing code.

//Requirements:
//1.Create an abstract class or interface:
//IDiscountStrategy
//2.	Implement discount classes:
//•	RegularCustomerDiscount
//•	PremiumCustomerDiscount
//•	VipCustomerDiscount
//3.	Each class should implement a method:
//CalculateDiscount(double amount)
//Technical Constraints:
//•	Use interface or abstract class
//•	Existing classes should not be modified when adding new discounts
//•	Follow Open for Extension, Closed for Modification
//Expectations:
//	Students should implement:
//•	IDiscountStrategy
//•	3 Discount Classes
//•	A class that calculates the final price

//Program Flow Diagram:
//IDiscountStrategy -> Regular Discount, Premium Discount, VIP Discount	 -> PriceCalculator

//Learning Outcome:
//Students will understand:
//•	Extending functionality without modifying existing code
//•	Use of interfaces and polymorphism
//•	Real-world use of Strategy Pattern



using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            PriceCalculator calculator = new PriceCalculator();

            Console.Write("Enter purchase amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            IDiscountStrategy regular = new RegularCustomerDiscount();
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            IDiscountStrategy vip = new VipCustomerDiscount();

            Console.WriteLine("Regular Customer Price: " +
                calculator.CalculateFinalPrice(amount, regular));

            Console.WriteLine("Premium Customer Price: " +
                calculator.CalculateFinalPrice(amount, premium));

            Console.WriteLine("VIP Customer Price: " +
                calculator.CalculateFinalPrice(amount, vip));
        }
    }
}
