//Level - 1 Problem 1: Student Score Analyzer Using Arrays and Maps
//Scenario:
//A training institute wants to analyze student scores stored in an array. The system should calculate total marks, average, highest score, and count of students scoring above a threshold.
//Requirements:
//-Store student marks in an array.
//- Use array methods (push, map, filter, reduce) for processing.
//- Store subject-wise highest marks using a Map (key - value pair).
//-Display total, average, and filtered results.
//Technical Constraints:
//-Must use array indexing and iteration.
//- Use reduce() for total calculation.
//- Use filter() for threshold-based filtering.
//- Use Map or Dictionary for subject-highest mapping.
//Sample Input:
//Marks: [78, 85, 90, 67, 88]
//Threshold: 80
//Sample Output:
//Total Marks: 408
//Average Marks: 81.6
//Students above 80: 3
//Highest Score: 90
//Expectations:
//-Clean and modular implementation.
//- Proper use of array methods.
//- Efficient iteration logic.
//Learning Outcome:
//-Understand array manipulation.
//-Use Map for key-value storage.
//- Apply functional programming methods.


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace upGrad_Week4_Day4
{
    internal class Student_Score_Analyzer_Using_Arrays_and_Maps
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            int[] marks = new int[n];

            // Input marks
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter marks for student {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            // Input threshold
            Console.Write("Enter threshold: ");
            int threshold = int.Parse(Console.ReadLine());

            // Dictionary (Map) for subject-wise highest
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>();
            subjectHighest["Math"] = marks.Max(); // Example mapping

            // ===== Calculations =====

            // Total using Reduce (Aggregate)
            int total = marks.Aggregate((sum, val) => sum + val);

            // Average
            double average = marks.Average();

            // Highest
            int highest = marks.Max();

            // Filter (above threshold)
            var aboveThreshold = marks.Where(m => m > threshold).ToArray();
            int countAbove = aboveThreshold.Length;

            // ===== Output =====
            Console.WriteLine("\n===== RESULT =====");
            Console.WriteLine($"Total Marks: {total}");
            Console.WriteLine($"Average Marks: {average}");
            Console.WriteLine($"Highest Score: {highest}");
            Console.WriteLine($"Students above {threshold}: {countAbove}");
        }
    }
}