using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographersController : ControllerBase
    {
        private readonly CampusQuartersDataContext _dataContext;

        public PhotographersController(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetPhotographers() 
        { 
            var photographers = _dataContext.Photographers.Include(photographer=>photographer.Account).ToList();
            return Ok(photographers);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPhotographerById(int id)
        {
            var photographer = _dataContext.Photographers.Include(photographer => photographer.Account).FirstOrDefault(p=>p.Id==id);
            if (photographer == null)
            {
                return NotFound("Photographer not found");
            }
            return Ok(photographer);
        }

        [HttpPost]
        public IActionResult PostPhotographer([FromBody]Photographer photographer)
        {
            if (photographer == null)
            {
                return BadRequest();
            }
            photographer.Account.RoleId = 1;
            _dataContext.Photographers.Add(photographer);
            _dataContext.SaveChanges();
            return Ok(photographer);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePhotographer(int id)
        {
            var photographer = _dataContext.Photographers.Include(photographer => photographer.Account).FirstOrDefault(p => p.Id == id);
            if (photographer == null)
            {
                return BadRequest("Photographer does not exist");
            }
            var account =_dataContext.Account.FirstOrDefault(p => p.Id == photographer.Account.Id);
            if (account == null)
            {
                return BadRequest("Account does not exist");
            }
            _dataContext.Photographers.Remove(photographer);
            _dataContext.Account.Remove(account);
            _dataContext.SaveChanges();
            return Ok("Photographer account successfully deleted");
        }
    }
}
