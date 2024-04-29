using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Accommodation;
using CampusQuartersAPI.Mappers;
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
                .Include(accommodation => accommodation.Availability)
                .Include(accommodation => accommodation.Availability.Status)
                .Include(createAccommodation => createAccommodation.Landlord)
                .Include(accommodation => accommodation.Videos)
                .Include(accommodation => accommodation.Images)
               .ToList();

            var accommodationDto = accommodation.Select(a => a.ToAccommodationDto());
            return Ok(accommodationDto);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAccommodationById(int id)
        {
            var accommodation = _dataContext.Accommodations.FirstOrDefault(x => x.Id == id);
            if (accommodation == null)
            {
                return NotFound("Accommodation does not exist");
            }
            return Ok(accommodation.ToAccommodationDto());
        }
        [HttpPost]
        public IActionResult PostAccommodation([FromBody] CreateAccommodationDto createAccommodation)
        {
            if (createAccommodation == null)
            {
                return BadRequest();
            }
            Accommodation accommodation = createAccommodation.ToAccommodationFromCreateDto();
            _dataContext.Accommodations.Add(accommodation);
            _dataContext.SaveChanges();
            return Ok(accommodation.ToAccommodationDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAccommodation(int id)
        {
            var accommodation = _dataContext.Accommodations.Include(accommodation => accommodation.Type).Include(accommodation => accommodation.Images).Include(accommodation => accommodation.Availability).FirstOrDefault(x => x.Id == id);
            if (accommodation == null)
            {
                return NotFound("Accommodation does not exist");
            }
            try
            {
                _dataContext.Accommodations.Remove(accommodation);

                if (accommodation.Availability != null)
                    _dataContext.Availability.Remove(accommodation.Availability);

                if (accommodation.Images != null)
                {
                    foreach (var image in accommodation.Images)
                    {
                        _dataContext.AccommodationImages.Remove(image);
                    }
                }
                if (accommodation.Videos != null)
                {
                    foreach (var video in accommodation.Videos)
                    {
                        _dataContext.AccommodationVideos.Remove(video);
                    }
                }
                _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Accommodation successfully deleted");
        }
    }
}
