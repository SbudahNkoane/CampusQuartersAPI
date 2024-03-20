using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
            var students = _context.Students.ToList();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound("This student does not exist");
            }
            return Ok(student);
        }

        [HttpPost]

        public IActionResult PostStudent([FromBody]Student student)
        {
             student.Account.RoleId = 1;
            _context.Students.Add(student);
            
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id) 
        {
            var student = _context.Students.FirstOrDefault(_x => _x.Id == id);
            if(student == null)
            {
                return BadRequest("Student does not exist");
            }
            _context.Students.Remove(student); 
            _context.SaveChanges();

            return Ok();
        }
    }
}
