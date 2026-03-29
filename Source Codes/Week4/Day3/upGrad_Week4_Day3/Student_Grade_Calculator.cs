//Level - 1 Problem 1: Student Grade Calculator
//Scenario:
//A school wants to calculate the average marks of a student using a class-based approach.
//Requirements:
//1.Create a class Student.
//2.Create method CalculateAverage(int m1, int m2, int m3).
//3.Return the average marks.
//4. Display grade based on average.
//Technical Constraints:
//1.Use return type double for average.
//2. Avoid hard-coded values.
//Expectations:
//Clear separation of logic inside methods.
//Learning Outcome:
//Learn method creation, return values, and basic OOP concepts.
//Sample Input:
//80 70 90
//Sample Output:
//Average = 80, Grade = A

using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day3
{
    internal class Student_Grade_Calculator
    {
        class Student
        {
            public double Average_Marks(int marks1, int marks2, int marks3)
            {
                double Average = (marks1 + marks2 + marks3) / 3.0;
                return Average;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {

                Console.Write("Enter the 1st Subject Marks: ");
                int marks1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the 2nd Subject Marks: ");
                int marks2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the 3rd Subject Marks: ");
                int marks3 = Convert.ToInt32(Console.ReadLine());

                Student objStudent = new Student();

                double Average = objStudent.Average_Marks(marks1, marks2, marks3);

                string Grade;

                if(Average >= 80)
                {
                    Grade = "A";
                }

                else if(Average >= 60)
                {
                    Grade = "B";
                }

                else if(Average >= 40)
                {
                    Grade = "C";
                }
                else
                {
                    Grade = "Fail";
                }

                Console.WriteLine("Average = " + Average + ", Grade = " + Grade);
            }
        }
    }
}
