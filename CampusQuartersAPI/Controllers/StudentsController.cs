﻿using CampusQuartersAPI.Data;
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
            var students = _context.Students.Include(b => b.Bookings).Include(a => a.Account).ToList();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students.Include(b => b.Bookings).Include(a => a.Account).FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound("This student does not exist");
            }
            return Ok(student);
        }


        //Register a Student
        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            //make sure the student account registers as normal user account
            student.Account.RoleId = 1;

            _context.Students.Add(student);

            _context.SaveChanges();
            return Ok(student);
        }

        //Delete a Student
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Include(b=>b.Bookings).Include(a => a.Account).FirstOrDefault(_x => _x.Id == id);
            if (student == null)
            {
                return BadRequest("Student does not exist");
            }
          //  var bookings = _context.Bookings.Where(booking=>booking.);
            var account = _context.Account.FirstOrDefault(a => a.Id == student.Account.Id);
            if (account == null)
            {
                return BadRequest("Account Not found");
            }

            _context.Students.Remove(student);
            _context.Account.Remove(account);

            _context.SaveChanges();

            return Ok("Student successfully deleted");
        }
    }
}
