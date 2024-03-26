using CampusQuartersAPI.Data;
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
            var students = _context.Students.Include(a => a.Account).ToList();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students.Include(a=>a.Account).FirstOrDefault(x => x.Id == id);
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
            var student = _context.Students.Include(a => a.Account).FirstOrDefault(_x => _x.Id == id);
            if(student == null)
            {
                return BadRequest("Student does not exist");
            }
            _context.Students.Remove(student);
            var account =_context.Account.FirstOrDefault(a=>a.Id==student.Account.Id);
            if (account == null)
            {
                return BadRequest();
            }

            _context.Account.Remove(account);

            _context.SaveChanges();

            return Ok();
        }
    }
}
