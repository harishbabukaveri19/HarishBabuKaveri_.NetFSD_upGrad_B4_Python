//Level - 1 Problem 1:
//Scenario
//A financial application needs to process multiple reports simultaneously to reduce waiting time. Instead of executing tasks sequentially, the system should run them concurrently using C# Tasks so that reports are generated faster.
//Requirements
//1.Create three methods:
//a.GenerateSalesReport()
//b.GenerateInventoryReport()
//c.GenerateCustomerReport()
//2.Each method should simulate processing time using Thread.Sleep() or Task.Delay().
//3.Execute all three operations concurrently using Task.
//4.Display a message when each report starts and when it finishes.
//5.	Display a final message once all reports are completed.
//Technical Constraints
//•	Use Task class from System.Threading.Tasks.
//•	Use Task.Run() to execute methods.
//•	Use Task.WaitAll() or await Task.WhenAll() to wait for completion.
//•	The program must run in a Console Application.
//Expectations
//The program should start multiple report-generation tasks simultaneously and display completion messages for each report along with a final message once all tasks are completed.
//Learning Outcome
//Students will learn:
//•	How to create and run Tasks in C#
//•	How to execute multiple operations concurrently
//•	How to wait for multiple tasks to complete


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day3
{
    internal class ProblemStatement1
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting report generation...\n");

            // Run tasks concurrently
            Task salesTask = Task.Run(() => GenerateSalesReport());
            Task inventoryTask = Task.Run(() => GenerateInventoryReport());
            Task customerTask = Task.Run(() => GenerateCustomerReport());

            // Wait for all tasks to complete
            await Task.WhenAll(salesTask, inventoryTask, customerTask);

            Console.WriteLine("\nAll reports generated successfully!");
        }

        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started...");
            await Task.Delay(3000); // Simulate processing
            Console.WriteLine("Sales Report Completed.");
        }

        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started...");
            await Task.Delay(4000);
            Console.WriteLine("Inventory Report Completed.");
        }

        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started...");
            await Task.Delay(2000);
            Console.WriteLine("Customer Report Completed.");
        }
    }
}
