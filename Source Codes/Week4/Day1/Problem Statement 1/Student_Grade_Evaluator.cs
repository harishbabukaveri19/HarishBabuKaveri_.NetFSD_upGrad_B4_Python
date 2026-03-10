using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Student_Grade_Evaluator
    {
        static void Main()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please Enter a Valid Student Name.");
            }
            else
            {

                Console.Write("Enter your marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                if (marks < 0 || marks > 100)
                {
                    Console.WriteLine("Invalid Marks. Please Enter the Marks (1-100)");
                }
                else if (marks >= 90)
                {
                    Console.WriteLine("Student: " + name);
                    Console.WriteLine("Grade A");
                }
                else if (marks >= 70)
                {
                    Console.WriteLine("Student: " + name);
                    Console.WriteLine("Grade B");
                }
                else if (marks >= 50)
                {
                    Console.WriteLine("Student: " + name);
                    Console.WriteLine("Grade C");
                }
                else if (marks >= 35)
                {
                    Console.WriteLine("Student: " + name);
                    Console.WriteLine("Grade D");
                }
                else
                {
                    Console.WriteLine("Student: " + name);
                    Console.WriteLine("Fail");
                }
            }
        }
    }
}