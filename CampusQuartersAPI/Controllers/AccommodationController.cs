using CampusQuartersAPI.Data;
using CampusQuartersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly CampusQuartersDataContext _dataContext;

        public AccommodationController(CampusQuartersDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult GetAccommodation()
        {
            var accommodation = _dataContext.Accommodations
                .Include(accommodation => accommodation.Type)
                .Include(accommodation => accommodation.Availability.Status)
                //.Include(accommodation => accommodation.Landlord)
                .Include(accommodation => accommodation.Videos)
                .Include(accommodation => accommodation.Images)
                .Include(accommodation => accommodation.Availability).ToList();
            return Ok(accommodation);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAccommodationById(int id)
        {
            var accommodation = _dataContext.Accommodations.FirstOrDefault(x => x.Id == id);
            if (accommodation == null)
            {
                return NotFound("Accommodation does mot exist");
            }
            return Ok(accommodation);
        }
        [HttpPost]
        public IActionResult PostAccommodation([FromBody] Accommodation accommodation)
        {
            if (accommodation == null)
            {
                return BadRequest();
            }
            _dataContext.Accommodations.Add(accommodation);
            _dataContext.SaveChanges();
            return Ok(accommodation);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAccommodation(int id)
        {
            var accommodation = _dataContext.Accommodations.Include(accommodation => accommodation.Type).Include(accommodation => accommodation.Images).Include(accommodation => accommodation.Availability).FirstOrDefault(x => x.Id == id);
            if (accommodation == null)
            {
                return NotFound("Accommodation does mot exist");
            }
            return Ok();
        }
    }
}
