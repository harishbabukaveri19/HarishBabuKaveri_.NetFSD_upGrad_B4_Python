using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
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
