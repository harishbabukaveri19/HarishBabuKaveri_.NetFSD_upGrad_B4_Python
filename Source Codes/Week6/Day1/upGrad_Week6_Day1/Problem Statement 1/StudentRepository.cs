using System;
using System.Collections.Generic;
using System.Text;
using upGrad_Week6_Day1.Problem_Statement_1;

namespace upGrad_Week6_Day1.Problem_Statement_1
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                Console.WriteLine("Invalid student name.");
            }

            if (student.Marks < 0 || student.Marks > 100)
            {
                Console.WriteLine("Marks must be between 0 and 100.");
            }

            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}