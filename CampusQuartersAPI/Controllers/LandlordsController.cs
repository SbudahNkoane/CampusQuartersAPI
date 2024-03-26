using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordsController : ControllerBase
    {
        private readonly CampusQuartersDataContext _dataContext;

        public LandlordsController(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult GetLandlords() 
        {
           var landlords= _dataContext.Landlords.Include(a => a.Account).ToList();
           
            return Ok(landlords);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLandlordById(int id) 
        {
            var landlord = _dataContext.Landlords.Include(a => a.Account).FirstOrDefault(l=>l.Id==id);
            if (landlord == null)
            {
                return NotFound("Landlord does not exist");
            }
            return Ok(landlord);
        }

        [HttpPost]
        public IActionResult PostLandlord([FromBody]Landlord landlord)
        {
            if (landlord == null)
            {
                return BadRequest();
            }
            //make sure the landlord account registers as normal user account
            landlord.Account.RoleId = 1;

            _dataContext.Landlords.Add(landlord);
            _dataContext.SaveChanges();

            return Ok(landlord);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteLandlord(int id)
        {
            var landlord = _dataContext.Landlords.Include(a=>a.Account).FirstOrDefault(l => l.Id == id);
            if (landlord == null)
            {
                return NotFound("Landlord does not exist");
            }
            var account = _dataContext.Account.FirstOrDefault(a=>a.Id == landlord.Account.Id);
            if (account == null)
            {
                return NotFound("Account does not exist");
            }
            _dataContext.Landlords.Remove(landlord);
            _dataContext.Account.Remove(account);
            _dataContext.SaveChanges();

            return Ok("Landlord successfully deleted");
        }
    }
}
