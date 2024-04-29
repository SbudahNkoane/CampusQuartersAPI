using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Administrator;
using CampusQuartersAPI.Mappers;
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
            var admins =_dataContext.Administrators.ToList();
            var adminsDto = admins.Select(a => a.ToAdministratorDto());
            return Ok(adminsDto);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAdmin(int id)
        {
            var admin = _dataContext.Administrators.FirstOrDefault(ad => ad.Id == id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin.ToAdministratorDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateAdministrator([FromBody]UpdateAdministratorDto updateAdministrator, [FromRoute]int id)
        {
            var adminFound = _dataContext.Administrators.FirstOrDefault(a => a.Id == id);
            if(adminFound == null)
            {
                return NotFound();
            }

            //Only 3 fields can be updated on user accounts:
            adminFound.CellNumber = updateAdministrator.CellNumber;
            adminFound.Name = updateAdministrator.Name;
            adminFound.Surname = updateAdministrator.Surname;

            _dataContext.SaveChanges();

            return Ok(adminFound.ToAdministratorDto());
        }
        [HttpPost]
        public IActionResult PostAdmin([FromBody]CreateAdministratorDto createAdministrator)
        {
            var administrator = createAdministrator.ToAdministratorFromCreateDto();
            _dataContext.Administrators.Add(administrator);
            _dataContext.SaveChanges();

            return Ok(administrator.ToAdministratorDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            var admin = _dataContext.Administrators.Include(admin=>admin.Account).FirstOrDefault(ad=>ad.Id==id);
            if (admin == null)
            {
                return BadRequest("Administrator does not exist");
            }
            _dataContext.Administrators.Remove(admin);
            _dataContext.Account.Remove(admin.Account);
            _dataContext.SaveChanges();
            return Ok("Administrator account successfully deleted");
        }
    }
}
