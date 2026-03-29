//Level - 2 Problem 3: Employee Salary Calculator
//Scenario:
//A company wants to calculate employee salaries using inheritance.All employees have a base salary, but different roles calculate bonuses differently.
//Requirements:
//1.Create a base class Employee with Name and BaseSalary properties.
//2. Create derived classes Manager and Developer.
//3. Override a virtual method CalculateSalary().
//4. Manager gets 20% bonus, Developer gets 10% bonus.
//Technical Constraints:
//• Use inheritance and method overriding.
//• Apply polymorphism using base class reference.
//• Use properties for salary details.
//Expectations:
//• Demonstrate runtime polymorphism.
//• Avoid code duplication.
//• Display final calculated salary.
//Learning Outcome:
//• Understand inheritance hierarchy.
//• Implement polymorphism using virtual and override.
//• Write reusable and extensible code.
//Sample Input: 
//BaseSalary = 50000
//Sample Output: 
//Manager Salary = 60000, Developer Salary = 55000


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day3
{
    internal class Employee_Salary_Calculator
    {
        class Employee
        {
            // Properties
            public string Name { get; set; }
            public double BaseSalary { get; set; }

            // Virtual method
            public virtual double CalculateSalary()
            {
                return BaseSalary;
            }
        }

        // Derived class: Manager
        class Manager : Employee
        {
            public override double CalculateSalary()
            {
                return BaseSalary + (0.20 * BaseSalary); // 20% bonus
            }
        }

        // Derived class: Developer
        class Developer : Employee
        {
            public override double CalculateSalary()
            {
                return BaseSalary + (0.10 * BaseSalary); // 10% bonus
            }
        }

        class Program
        {
            static void Main()
            {
                Console.Write("Enter Base Salary: ");
                double baseSalary = Convert.ToDouble(Console.ReadLine());

                // Polymorphism (base class reference)
                Employee manager = new Manager { Name = "Manager", BaseSalary = baseSalary };
                Employee developer = new Developer { Name = "Developer", BaseSalary = baseSalary };

                Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
                Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
            }
        }
    }
}