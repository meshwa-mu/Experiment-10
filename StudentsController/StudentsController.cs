
using Microsoft.AspNetCore.Mvc;
using Experiment_10.Models;

namespace Experiment_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Rahul",
                Email = "rahul@gmail.com",
                Age = 20,
                Course = "BCA"
            },
            new Student
            {
                Id = 2,
                Name = "Priya",
                Email = "priya@gmail.com",
                Age = 21,
                Course = "B.Tech"
            }
        };

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.Id = students.Count == 0
                ? 1 : students.Max(s => s.Id) + 1;

            students.Add(student);

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Age = updatedStudent.Age;
            student.Course = updatedStudent.Course;

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);

            return Ok("Student deleted successfully");
        }
    }
}
