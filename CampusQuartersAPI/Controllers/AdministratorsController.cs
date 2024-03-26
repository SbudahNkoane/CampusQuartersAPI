using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly CampusQuartersDataContext _dataContext;

        public AdministratorsController(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAdmins() 
        {
            var admins =_dataContext.Administrators.Include(admin => admin.Account).ToList();
            return Ok(admins);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAdmin(int id)
        {
            var admin = _dataContext.Administrators.Include(admin => admin.Account).FirstOrDefault(ad => ad.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
        [HttpPost]
        public IActionResult PostAdmin([FromBody]Administrator administrator)
        {
            administrator.Account.RoleId = 2;
            _dataContext.Administrators.Add(administrator);
            _dataContext.SaveChanges();

            return Ok(administrator);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            var admin = _dataContext.Administrators.Include(admin=>admin.Account).FirstOrDefault(ad=>ad.Id==id);
            if (admin == null)
            {
                return BadRequest("Administrato does not exist");
            }
            var account=_dataContext.Account.FirstOrDefault(Account => Account.Id==admin.Account.Id);
            if (account == null)
            {
                return BadRequest("Account does not exist");
            }
            _dataContext.Administrators.Remove(admin);
            _dataContext.Account.Remove(account);
            _dataContext.SaveChanges();
            return Ok("Administrator account successfully deleted");
        }
    }
}
