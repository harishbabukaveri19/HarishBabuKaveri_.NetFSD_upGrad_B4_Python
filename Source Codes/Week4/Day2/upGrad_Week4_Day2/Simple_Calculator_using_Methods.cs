/* Level - 1 Problem 1: Simple Calculator Using Methods
Scenario:
A small retail shop wants a simple calculator application to perform addition and subtraction operations using reusable methods.
Requirements:
1.Create a class named Calculator.
2.Create methods Add(int a, int b) and Subtract(int a, int b).
3.Each method should return the result.
4. In Main(), create an object and call the methods.
5. Display the output.
Technical Constraints:
1.Use method parameters and return types properly.
2. Use appropriate access modifiers.
3. No global variables allowed.
Expectations:
Proper method definition, object creation, and method invocation.
Learning Outcome:
Understand functions, parameters, return types, classes, and objects.
Sample Input: 10 5
Sample Output: Addition = 15, Subtraction = 5 */


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day2
{
    internal class Simple_Calculator_using_Methods
    {
        class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public int Subtract(int a, int b)
            {
                return a - b;
            }
            class Program
            {
                static void Main(string[] args)
                {
                    Console.Write("Enter First Number:");
                    int num1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Second Number:");
                    int num2 = Convert.ToInt32(Console.ReadLine());

                    Calculator objCalculator = new Calculator();

                    Console.WriteLine("Addition of " + num1 + " and " + num2 + " is " + objCalculator.Add(num1, num2));
                    Console.WriteLine("Subtraction of " + num1 + " and " + num2 + " is " + objCalculator.Subtract(num1, num2));

                }
            }
        }
    }
}
