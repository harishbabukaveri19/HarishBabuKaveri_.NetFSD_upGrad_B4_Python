//Problem 4- ISP – Interface Segregation Principle
//Scenario: Office Printer System
//An office has different machines:
//•	Basic Printer(Print only)
//•	Advanced Printer(Print + Scan + Fax)
//If we create a single large interface, basic printers will be forced to implement unnecessary methods.
//The task is to split the interface into smaller interfaces.

//Requirements:
//Create the following interfaces:
//•	IPrinter
//•	IScanner
//•	IFax

//Classes:
//•	BasicPrinter → Print only
//•	AdvancedPrinter → Print + Scan + Fax

//Technical Constraints:
//•	Follow Interface Segregation Principle
//•	Classes should not implement unnecessary methods

//Expectations:
//Students should implement:
//Interfaces
//•	IPrinter
//•	IScanner
//•	IFax
//Classes
//•	BasicPrinter
//•	AdvancedPrinter

//Program Flow Diagram:
//IPrinter, IScanner, IFax -> BasicPrinter Print(), AdvancedPrinter Print() Scan() Fax()

//Learning Outcome:
//Students will learn:
//•	Why large interfaces are bad
//•	How to design small focused interfaces
//•	Better maintainability and flexibility


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Printer Type:");
            Console.WriteLine("1. Basic Printer");
            Console.WriteLine("2. Advanced Printer");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                IPrinter printer = new BasicPrinter();
                printer.Print();
            }
            else if (choice == 2)
            {
                AdvancedPrinter printer = new AdvancedPrinter();

                printer.Print();
                printer.Scan();
                printer.Fax();
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}
