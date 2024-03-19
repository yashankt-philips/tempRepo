using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StudentRestAPI.Student;

namespace StudentRestAPI.Models
{
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> students = new List<Student>();

        public StudentRepository()
        {
            students.Add(new Student { StudentId = 1, Email = "abcd@gmail.com", Name = "ABCDa", Gender = Gender.Male });
            students.Add(new Student { StudentId = 2, Email = "abcde@gmail.com", Name = "ABCDe", Gender = Gender.Female });
            students.Add(new Student { StudentId = 3, Email = "abcdf@gmail.com", Name = "ABCDd", Gender = Gender.Other });
            students.Add(new Student { StudentId = 4, Email = "abcdg@gmail.com", Name = "ABCDf", Gender = Gender.Male });
        }

        public Boolean AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }

        public Boolean DeleteStudent(int studentId)
        {
            int index = -1;
            for(int i=0; i<students.Count; i++)
            {
                Student obj = students[i];
                if (obj.StudentId == studentId)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return false;
            }
            else
            {
                students.RemoveAt(index);
                return true;
            }
        }

        public Student GetStudent(int studentId)
        {
            foreach (Student s in students)
            {
                if (s.StudentId == studentId)
                {
                    return s;
                }
            }

            return null;
        }

        public Student GetStudentByEmail(string email)
        {
            foreach (Student s in students)
            {
                if (s.Email == email)
                {
                    return s;
                }
            }

            return null;
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
