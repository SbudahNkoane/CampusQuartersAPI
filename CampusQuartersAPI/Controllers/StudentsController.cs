using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Student;
using CampusQuartersAPI.Mappers;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CampusQuartersDataContext _context;

        public StudentsController(CampusQuartersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students
                .ToList();
            var studentsDto = students.Select(s => s.ToStudentDto());

            return Ok(studentsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students
              //  .Include(b => b.Bookings)
              //  .Include(a => a.Account)
                .FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound("This student does not exist");
            }
            return Ok(student.ToStudentDto());
        }


        //Register a Student
        [HttpPost]
        public IActionResult PostStudent([FromBody] CreateStudentDto studentDto)
        {
           
            Student student = studentDto.ToStudentFromCreateDto();
           

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student.ToStudentDto());
        }

        [HttpPut]
        [Route("{studentId}")]
        public IActionResult UpdateStudent([FromRoute] int studentId, [FromBody] UpdateStudentDto studentDto)
        {
            var studentModel= _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (studentModel == null)
            {
                return BadRequest("Student Not found");
            }
            studentModel.StudentNumber = studentDto.StudentNumber;
            studentModel.Surname = studentDto.Surname;
            studentModel.CellNumber = studentDto.CellNumber;
            studentModel.Name = studentDto.Name;
            _context.SaveChanges();

            return Ok(studentModel.ToStudentDto());
        }

        //Delete a Student
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students
                .Include(a => a.Account)
                .FirstOrDefault(_x => _x.Id == id);
            if (student == null)
            {
                return BadRequest("Student does not exist");
            }

            _context.Students.Remove(student);
            _context.Account.Remove(student.Account);

            _context.SaveChanges();

            return Ok("Student successfully deleted");
        }
    }
}
