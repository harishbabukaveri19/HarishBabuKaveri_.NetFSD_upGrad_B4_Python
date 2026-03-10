using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
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
