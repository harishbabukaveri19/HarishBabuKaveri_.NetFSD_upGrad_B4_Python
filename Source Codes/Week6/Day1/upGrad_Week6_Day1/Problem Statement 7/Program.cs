//Problem 7- Implementing Repository Pattern
//Scenario: Student Data Management System
//A training institute needs a system to manage student information.
//Instead of directly writing database access code in the main program, the development team decides to use the Repository Pattern.
//The repository will act as a data access layer between the application and the data source.
//For simplicity, student data will be stored in a List collection.

//ClientProgram -> StudentService -> StudentRepository -> StudentStorage(List<Student>)
 
//Requirements:
//Create the following components:
//Entity Class:
//Student
//Properties:
//StudentId
//StudentName
//Course
//Repository Interface:
//IStudentRepository
//Methods:
//AddStudent(Student student)
//GetAllStudents()
//GetStudentById(int id)
//DeleteStudent(int id)

//Repository Implementation:
//	StudentRepository
//Store data using:
//List<Student>

//Main Program
//Demonstrate:
//•	Adding students
//•	Viewing students
//•	Finding student by ID
//•	Deleting student

//Expectations:
//Students should implement separation between:
//Business Logic
//        ↓
//Repository Layer
//        ↓
//Data Storage


//Learning Outcome:
//Students will understand:
//•	Separation of concerns
//•	Data access abstraction
//•	Clean architecture basics
//•	How repositories simplify data operations


using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository repo = new StudentRepository();
            StudentService service = new StudentService(repo);

            while (true)
            {
                Console.WriteLine("\n1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Find Student by ID");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        string course = Console.ReadLine();

                        service.AddStudent(new Student
                        {
                            StudentId = id,
                            StudentName = name,
                            Course = course
                        });
                        break;

                    case 2:
                        var students = service.GetAllStudents();
                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.StudentId} - {s.StudentName} - {s.Course}");
                        }
                        break;

                    case 3:
                        Console.Write("Enter ID: ");
                        int searchId = Convert.ToInt32(Console.ReadLine());

                        var student = service.GetStudentById(searchId);
                        if (student != null)
                            Console.WriteLine($"{student.StudentName} - {student.Course}");
                        else
                            Console.WriteLine("Student not found");
                        break;

                    case 4:
                        Console.Write("Enter ID to delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        service.DeleteStudent(deleteId);
                        Console.WriteLine("Deleted (if existed)");
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
