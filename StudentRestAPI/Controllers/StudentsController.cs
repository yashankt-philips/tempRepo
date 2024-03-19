using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult SearchById(int id)
        {
            try
            {
                Student student = studentRepository.GetStudent(id);
                if (student != null)
                {
                    return StatusCode(StatusCodes.Status200OK, student);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, null);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some error occurred while searching");
            }
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                List<Student> students = studentRepository.GetStudents();
                return StatusCode(StatusCodes.Status200OK, students);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some error occurred while searching");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                Boolean isDeleted = studentRepository.DeleteStudent(id);
                if (isDeleted)
                {
                    return StatusCode(StatusCodes.Status200OK, "The entry has been deleted");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "The entry to be deleted was not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some error occurred while deleting");
            }
        }

        [HttpGet("{email}")]
        public IActionResult GetStudentByEmail(string email)
        {
            try
            {
                Student student = studentRepository.GetStudentByEmail(email);
                if (student != null)
                {
                    return StatusCode(StatusCodes.Status200OK, student);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, null);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Some error occurred while searching");
            }
        }
    }
}
