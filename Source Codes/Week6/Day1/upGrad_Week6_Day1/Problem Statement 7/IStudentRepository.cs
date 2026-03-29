using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_7
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }
}
