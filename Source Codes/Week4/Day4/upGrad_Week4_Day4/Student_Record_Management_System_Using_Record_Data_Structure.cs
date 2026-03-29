//Level - 2 Problem 2: Student Record Management System Using Record Data Structure

//Scenario:
//A college wants to develop a console-based Student Record Management System. The system should store and manage student records using a Record data structure. Each student record should contain fields such as Roll Number, Name, Course, and Marks. The system must allow users to add multiple student records, display all records, and search for a student using the Roll Number.
//Requirements:
//1.Define a Record to store student details.
//2. Allow the user to input details for multiple students.
//3. Display all student records in a formatted manner.
//4. Provide a search functionality to find a student by Roll Number.
//5. Display appropriate message if the record is not found.
//Technical Constraints:
//1.Must use Record data type.
//2. Use an array (or list) of records to store multiple students.
//3. Do not use external databases.
//4. Program should be menu-driven.
//5. Input validation must be handled for Roll Number and Marks.

//Sample Input:
//Enter number of students: 2
//Enter Roll Number: 101
//Enter Name: Aisha
//Enter Course: BCA
//Enter Marks: 85

//Enter Roll Number: 102
//Enter Name: Rahul
//Enter Course: BSc
//Enter Marks: 78

//Search Roll Number: 101

//Sample Output:
//Student Records:
//Roll No: 101 | Name: Aisha | Course: BCA | Marks: 85
//Roll No: 102 | Name: Rahul | Course: BSc | Marks: 78

//Search Result:
//Student Found:
//Roll No: 101 | Name: Aisha | Course: BCA | Marks: 85

//Expectations:
//1.Proper use of Record / Structure syntax.
//2. Clean and modular code.
//3. Proper formatting of displayed output.
//4. Efficient search implementation.
//Learning Outcome:
//1.Understand how to define and use Record/Structure data types.
//2. Learn how to manage multiple records using arrays/ lists.
//3.Implement searching techniques on structured data.
//4. Develop structured problem-solving skills for real-world scenarios.


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week4_Day4
{
    internal class Student_Record_Management_System_Using_Record_Data_Structure
    {
        public record Student(int RollNumber, string Name, string Course, int Marks);

        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            // Input student details
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}:");

                int roll;
                while (true)
                {
                    Console.Write("Enter Roll Number: ");
                    if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                        break;
                    Console.WriteLine("Invalid Roll Number. Try again.");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                int marks;
                while (true)
                {
                    Console.Write("Enter Marks: ");
                    if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                        break;
                    Console.WriteLine("Invalid Marks (0–100 only). Try again.");
                }

                students[i] = new Student(roll, name, course, marks);
            }

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search by Roll Number");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayStudents(students);
                        break;

                    case 2:
                        Console.Write("Enter Roll Number to search: ");
                        int searchRoll = int.Parse(Console.ReadLine());
                        SearchStudent(students, searchRoll);
                        break;

                    case 3:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        // Display all students
        static void DisplayStudents(Student[] students)
        {
            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        // Search student by Roll Number
        static void SearchStudent(Student[] students, int roll)
        {
            foreach (var s in students)
            {
                if (s.RollNumber == roll)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    return;
                }
            }

            Console.WriteLine("\nStudent not found.");
        }
    }
}