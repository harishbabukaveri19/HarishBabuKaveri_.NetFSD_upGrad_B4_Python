//Problem: 1 - SRP – Single Responsibility Principle
//Scenario: Student Report Generator
//A training institute like Codempower Academy maintains student information and generates performance reports. Currently, one class performs student data storage and report generation, which makes the code difficult to maintain.


//Requirements:
//1.Create a Student class with properties:
//•	StudentId
//•	StudentName
//•	Marks
//2.Create a class responsible for managing student data.
//3.Create a separate class responsible for generating reports.
//4.The report should display:

//Security Requirements(Secure Coding Practices)
//Students must implement the following security measures:


//Technical Constraints:
//•	Use C# (.NET Console Application).
//•	Each class must have only one responsibility.
//•	Do not mix data storage and report generation logic in the same class.

//Expectations:
//Students should implement at least three classes:
//•	Student
//•	StudentRepository
//•	ReportGenerator


//Program Flow Diagram

//Student -> StudentRepository(Manage Data) -> ReportGenerator(Print Report)

//Learning Outcome:
//Students will learn:
//•	Meaning of Single Responsibility Principle
//•	How to separate responsibilities
//•	How SRP improves maintainability and testing


using System;
using System.Collections.Generic;
using System.Text;
using upGrad_Week6_Day1.Problem_Statement_1;

namespace upGrad_Week6_Day1.Problem_Statement_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            StudentRepository ObjRepo = new StudentRepository();
            ReportGenerator ObjReport = new ReportGenerator();

            ObjRepo.AddStudent(new Student { StudentId = 1, StudentName = "Harish", Marks = 85 });
            ObjRepo.AddStudent(new Student { StudentId = 2, StudentName = "Balaji", Marks = 74 });
            ObjRepo.AddStudent(new Student { StudentId = 3, StudentName = "Ajay", Marks = 30 });
            ObjRepo.AddStudent(new Student { StudentId = 4, StudentName = "Pavan", Marks = 69 });

            var students = ObjRepo.GetAllStudents();
            ObjReport.GenerateReport(students);
        }
    }
}