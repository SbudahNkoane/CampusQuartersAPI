using CampusQuartersAPI.Dtos.Landlord;
using CampusQuartersAPI.Mappers;
using CampusQuartersAPI.Models;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordsController : ControllerBase
    {
        private readonly ILandlordRepository _landlordRepository;

        public LandlordsController(ILandlordRepository landlordRepository)
        {
            _landlordRepository = landlordRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetLandlords()
        {
            var landlords = await _landlordRepository.GetAllLandlordsAsync();
            var landlordsDto = landlords.Select(l => l.ToLandlordDto());

            return Ok(landlordsDto);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLandlordById(int id)
        {
            var landlord = await _landlordRepository.GetLandlordByIdAsync(id);
            if (landlord == null)
            {
                return NotFound("Landlord does not exist");
            }
            return Ok(landlord.ToLandlordDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateLandlord([FromRoute] int id, [FromBody] UpdateLandlordDto updateLandlord)
        {
            var landlord = await _landlordRepository.UpdateLandlordAsync(id, updateLandlord);
            if (landlord == null)
            {
                return BadRequest("Landlord does not exist!!");
            }

            return Ok(landlord.ToLandlordDto());
        }

        [HttpPost]
        public async Task<IActionResult> PostLandlord([FromBody] CreateLandlordDto landlordDto)
        {
            if (landlordDto == null)
            {
                return BadRequest();
            }
            Landlord landlord = await _landlordRepository.CreateLandlordAsync(landlordDto.ToLandlordFromCreateDto());

            return Ok(landlord.ToLandlordDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLandlord(int id)
        {
            var landlord = await _landlordRepository.DeleteLandlordAsync(id);
            if (landlord == null)
            {
                return BadRequest("Landlord does not exist");
            }


            return Ok("Landlord successfully deleted");
        }
    }
}
