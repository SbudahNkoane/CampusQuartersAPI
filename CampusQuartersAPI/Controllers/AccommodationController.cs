using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Accommodation;
using CampusQuartersAPI.Mappers;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public AccommodationController(CampusQuartersDataContext dataContext, IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAccommodation()
        {
            var accommodation = await _accommodationRepository.GetAllAccommodationsAsync();
            if (accommodation == null)
            {
                return BadRequest();
            }

            var accommodationDto = accommodation.Select(a => a.ToAccommodationDto());
            return Ok(accommodationDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAccommodationById(int id)
        {
            var accommodation = await _accommodationRepository.GetAccommodationByIdAsync(id);
            if (accommodation == null)
            {
                return NotFound("Accommodation does not exist");
            }
            var accommodationDto = accommodation.ToAccommodationDto();
            return Ok(accommodationDto);
        }
        [HttpPost]
        public IActionResult PostAccommodation([FromBody] CreateAccommodationDto createAccommodation)
        {
            if (createAccommodation == null)
            {
                return BadRequest();
            }
            Accommodation accommodation = createAccommodation.ToAccommodationFromCreateDto();
            try
            {
                _accommodationRepository.CreateAccommodationAsync(accommodation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(accommodation.ToAccommodationDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAccommodation(int id)
        {
            try
            {
             var accommodation =  await _accommodationRepository.DeleteAccommodationAsync(id);
                if (accommodation == null)
                {
                    return NotFound("Accommodation does not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            

            return Ok("Accommodation successfully deleted");
        }
    }
}
