using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_7
{
    public class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                Console.WriteLine("Invalid student name");
                return;
            }

            repository.AddStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return repository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return repository.GetStudentById(id);
        }

        public void DeleteStudent(int id)
        {
            repository.DeleteStudent(id);
        }
    }
}
