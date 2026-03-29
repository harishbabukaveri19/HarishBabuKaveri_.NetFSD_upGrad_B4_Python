//Level - 2 Problem 3: Application Tracing for Order Processing
//Scenario
//An e-commerce application processes customer orders. Sometimes the order processing fails, but developers are unable to identify where the failure occurs. The team decides to implement Tracing to monitor the execution flow and diagnose the issue.
//Requirements
//•	Create a console application that simulates order processing.
//•	The order processing should include the following steps:
//1.Validate Order
//2.	Process Payment
//3.	Update Inventory
//4.	Generate Invoice
//•	Use Trace class to log messages at each step of the process.
//•	Display trace messages showing the execution flow.
//Technical Constraints
//•	Use System.Diagnostics.Trace.
//•	Write trace messages using:
//o Trace.WriteLine()
//o Trace.TraceInformation()
//•	Configure a TextWriterTraceListener to store trace logs in a file.
//•	Implement the solution using .NET console application.
//Expectations
//•	The application should log messages for each stage of order processing.
//•	Trace logs should help developers identify where failures occur.
//•	The trace output should be stored in a log file.
//Learning Outcome
//Students will learn how to:
//•	Implement application tracing using System.Diagnostics.
//•	Monitor application flow using Trace listeners.
//•	Use trace logs to diagnose runtime issues in real-world applications.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upGrad_Week5_Day3
{
    internal class ProblemStatement5
    {
        static void Main(string[] args)
        {
            // Configure Trace to write into a file
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("trace_log.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            try
            {
                ProcessOrder();
            }
            catch (Exception ex)
            {
                Trace.TraceInformation("ERROR: " + ex.Message);
                Console.WriteLine("Order processing failed!");
            }

            Console.WriteLine("\nCheck 'trace_log.txt' for logs.");
        }

        static void ProcessOrder()
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validating Order...");
            Console.WriteLine("Validating Order...");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing Payment...");
            Console.WriteLine("Processing Payment...");

            // Simulate failure (for debugging demo)
            bool paymentSuccess = true;

            if (!paymentSuccess)
            {
                Trace.TraceInformation("Payment failed!");
                throw new Exception("Payment Error");
            }
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Updating Inventory...");
            Console.WriteLine("Updating Inventory...");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating Invoice...");
            Console.WriteLine("Generating Invoice...");
        }
    }
}
