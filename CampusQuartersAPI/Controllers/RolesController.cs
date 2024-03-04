using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly CampusQuartersDataContext _context;

        public RolesController(CampusQuartersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRoles() 
        {
            var roles = _context.Roles.ToList();

            
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(i => i.Id==id);
            if(role == null)
            {
                return NotFound("This Role does not exist");
            }
            return Ok(role);
        }
    }
}
