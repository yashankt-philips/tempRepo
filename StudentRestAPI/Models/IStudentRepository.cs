using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRestAPI.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int studentId);
        List<Student> GetStudents();
        Student GetStudentByEmail(string email);
        Boolean AddStudent(Student student);
        Boolean DeleteStudent(int studentId);
    }
}
