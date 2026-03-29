//Level - 2 Problem 1: Asynchronous Order Processing System
//Scenario:
//An e-commerce system processes customer orders. Each order requires multiple steps such as payment verification, inventory check, and order confirmation. These steps involve delays and should be handled asynchronously.

//Requirements:
//-Create asynchronous methods:
//  -VerifyPaymentAsync()
//  - CheckInventoryAsync()
//  - ConfirmOrderAsync()
//- Simulate processing delays using Task.Delay().
//- Execute steps asynchronously while maintaining the logical order of operations.

//Technical Constraints:
//-Use async and await.
//- Use Task-based asynchronous methods.
//- Implement using a console application.

//Expectations:
//-Each processing step should run asynchronously.
//- The program should display messages indicating the progress of order processing.

//Learning Outcome:
//Students will understand how to design real-world workflows using asynchronous methods with async/await.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day3
{
    public class ProblemStatement3
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order Processing Started...\n");

            await ProcessOrderAsync();

            Console.WriteLine("\nOrder Processing Completed!");
        }

        static async Task ProcessOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying Payment...");
            await Task.Delay(2000);
            Console.WriteLine("Payment Verified");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking Inventory...");
            await Task.Delay(3000);
            Console.WriteLine("Inventory Available");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming Order...");
            await Task.Delay(1500);
            Console.WriteLine("Order Confirmed");
        }
    }
}
