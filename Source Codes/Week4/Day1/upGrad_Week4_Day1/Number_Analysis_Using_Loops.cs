//Level - 2 Problem 2: Number Analysis Using Loops
//Scenario
//Create a .NET 8 console application that analyzes numbers between 1 and N.
//Requirements
//• Accept a number N from user.
//• Use loops to:
//   -Count even numbers
//   -Count odd numbers
//   - Calculate sum of all numbers
//• Display results.
//Technical Constraints
//• Use for or while loop.
//• Use int data type.
//• Avoid using arrays or collections.
//Sample Input
//Enter Number: 10
//Sample Output
//Even Count: 5
//Odd Count: 5
//Sum: 55
//Expectations
//Proper loop usage and correct counting logic.
//Learning Outcome
//Strengthen understanding of loops, counters and accumulators in C#.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day1
{
    internal class Number_Analysis_Using_Loops
    {
        static void Main()
        {
            Console.Write("Enter a Number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int Even_Count = 0;
            int Odd_Count = 0;
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum +=  i;

                if(i%2==0)
                {
                    Even_Count++;
                }
                else
                {
                    Odd_Count++;
                }
            }
            Console.WriteLine("Even Count: " + Even_Count);
            Console.WriteLine("Odd Count: " + Odd_Count);
            Console.WriteLine("Sum: " + sum);
        }
    }
}
