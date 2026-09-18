using Microsoft.AspNetCore.Mvc;
using LibraryBorrowingApi.Models;

namespace LibraryBorrowingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                RFID = "RFID-2026-0001",
                StudentNumber = "2026-00001",
                FirstName = "Juan",
                MiddleName = "Santos",
                LastName = "Dela Cruz",
                Email = "juan.delacruz@example.com",
                ContactNumber = "09171234567",
                Course = "BS Information Technology",
                YearLevel = 2,
                Department = "College of Computing and Information Technology",
                Address = "123 Mabini Street, Tanauan City, Batangas"
            }
        };

        // GET: api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(students);
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            student.Id = students.Count == 0
                ? 1
                : students.Max(s => s.Id) + 1;

            students.Add(student);

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                student
            );
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }

            student.RFID = updatedStudent.RFID;
            student.StudentNumber = updatedStudent.StudentNumber;
            student.FirstName = updatedStudent.FirstName;
            student.MiddleName = updatedStudent.MiddleName;
            student.LastName = updatedStudent.LastName;
            student.Email = updatedStudent.Email;
            student.ContactNumber = updatedStudent.ContactNumber;
            student.Course = updatedStudent.Course;
            student.YearLevel = updatedStudent.YearLevel;
            student.Department = updatedStudent.Department;
            student.Address = updatedStudent.Address;

            return Ok(student);
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found."
                });
            }

            students.Remove(student);

            return Ok(new
            {
                message = "Student deleted successfully."
            });
        }
    }
}