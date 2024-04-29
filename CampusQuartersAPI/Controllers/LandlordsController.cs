using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Mappers;
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
            var landlordsDto = landlords.Select(l => l.ToLandlordDto());
           
            return Ok(landlordsDto);
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
            return Ok(landlord.ToLandlordDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateLandlord([FromRoute]int id, [FromBody] UpdateLandlordDto updateLandlord)
        {
          var landlordFound = _dataContext.Landlords.FirstOrDefault(l => l.Id==id);
            if (landlordFound == null)
            {
                return BadRequest("Landlord does not exist!!");
            }
            landlordFound.Name = updateLandlord.Name;
            landlordFound.Surname= updateLandlord.Surname;
            landlordFound.CellNumber = updateLandlord.CellNumber;
            _dataContext.SaveChanges();
            return Ok(landlordFound.ToLandlordDto());
        }

        [HttpPost]
        public IActionResult PostLandlord([FromBody]CreateLandlordDto landlordDto)
        {
            if (landlordDto == null)
            {
                return BadRequest();
            }
            Landlord landlord = landlordDto.ToLandlordFromCreateDto();

            _dataContext.Landlords.Add(landlord);
            _dataContext.SaveChanges();

            return Ok(landlord.ToLandlordDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteLandlord(int id)
        {
            var landlord = _dataContext.Landlords.Include(a=>a.Account).FirstOrDefault(l => l.Id == id);
            if (landlord == null)
            {
                return BadRequest("Landlord does not exist");
            }
            _dataContext.Landlords.Remove(landlord);
            _dataContext.Account.Remove(landlord.Account);
            _dataContext.SaveChanges();

            return Ok("Landlord successfully deleted");
        }
    }
}
