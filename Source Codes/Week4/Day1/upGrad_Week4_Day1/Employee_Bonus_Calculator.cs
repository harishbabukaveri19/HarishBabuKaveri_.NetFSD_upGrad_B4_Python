//Level - 2 Problem 1: Employee Bonus Calculator
//Scenario
//Develop a console application that calculates employee bonus based on salary and years of experience.
//Requirements
//• Accept employee name, salary and years of experience.
//• Use if-else and conditional operator.
//• Bonus rules:
//   -Experience < 2 years: 5 % bonus
//   - 2 - 5 years: 10 % bonus
//   - > 5 years: 15 % bonus
//• Display final salary after bonus.
//Technical Constraints
//• Use double for salary.
//• Use if-else and ternary operator.
//• Use proper formatting for currency output.
//Sample Input
//Enter Name: Aisha
//Enter Salary: 50000
//Enter Experience: 4
//Sample Output
//Employee: Aisha
//Bonus: 5000
//Final Salary: 55000
//Expectations
//Accurate bonus calculation and correct usage of control statements.
//Learning Outcome
//Apply conditional logic and arithmetic operations in real-world scenarios.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day1
{
    internal class Employee_Bonus_Calculator
    {
        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Experience: ");
            int experience = Convert.ToInt32(Console.ReadLine());

            double bonusPercent;

            if (experience < 2)
            {
                bonusPercent = 0.05;
            }
            else if (experience <= 5)
            {
                bonusPercent = 0.1;
            }
            else
            {
                bonusPercent = 0.15;
            }

            double bonus = salary * bonusPercent;

            double FinalSalary = salary + bonus;

            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Bonus: " + bonus);
            Console.WriteLine("Final Salary: " + FinalSalary);
        }
    }
}
