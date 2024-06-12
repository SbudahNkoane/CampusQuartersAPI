using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Student;
using CampusQuartersAPI.Mappers;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
           var students= await _studentRepository.GetAllStudentsAsync();
            if (students == null)
            {
                return BadRequest();
            }
            var studentDto = students.Select(s=>s.ToStudentDto()).ToList();
            return Ok(studentDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            //var student = _context.Students
            //  //  .Include(b => b.Bookings)
            //  //  .Include(a => a.Account)
            //    .FirstOrDefault(x => x.Id == id);
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound("This student does not exist");
            }
            return Ok(student.ToStudentDto());
        }


        //Register a Student
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] CreateStudentDto studentDto)
        {
           
            Student student = studentDto.ToStudentFromCreateDto();
           await _studentRepository.CreateStudentAsync(student);

            return Ok(student.ToStudentDto());
        }

        [HttpPut]
        [Route("{studentId}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int studentId, [FromBody] UpdateStudentDto studentDto)
        {
            var student = await _studentRepository.UpdateStudentAsync(studentId, studentDto);

            if (student == null)
            {
                return BadRequest("Student Not found");
            }
            return Ok(student.ToStudentDto());
        }

        //Delete a Student
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentRepository.DeleteStudentAsync(id);
            if (student == null)
            {
                return BadRequest("Student does not exist");
            }
            return Ok("Student successfully deleted");
        }
    }
}
