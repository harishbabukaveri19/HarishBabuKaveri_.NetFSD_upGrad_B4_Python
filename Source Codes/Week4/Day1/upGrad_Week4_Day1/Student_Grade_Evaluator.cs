//Level - 1 Problem 1: Student Grade Evaluator
//Scenario
//You are developing a console-based application in .NET 8 for a school. The application should evaluate a student’s marks and assign a grade based on predefined rules.
//Requirements
//• Accept student name and marks (0-100).
//• Use if-else statements to determine grade.
//• Display grade as A, B, C, D or Fail.
//• Handle invalid input using conditional checks.
//Technical Constraints
//• Use C# (.NET 8 Console Application).
//• Use appropriate data types (string, int).
//• Use if-else control flow.
//• Do not use advanced concepts like classes or LINQ.
//Sample Input
//Enter Name: Rahul
//Enter Marks: 78
//Sample Output
//Student: Rahul
//Grade: B
//Expectations
//Program should correctly evaluate grade and handle edge cases like marks below 0 or above 100.
//Learning Outcome
//Understand variables, data types, input/output handling and if-else control statements in C#.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day1
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

