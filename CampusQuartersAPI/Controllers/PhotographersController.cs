using CampusQuartersAPI.Dtos.Photographer;
using CampusQuartersAPI.Mappers;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographersController : ControllerBase
    {
        private readonly IPhotographerRepository _photographerRepository;

        public PhotographersController(IPhotographerRepository photographerRepository)
        {
            _photographerRepository = photographerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotographers()
        {
            var photographers = await _photographerRepository.GetAllPhotographersAsync();
            var photographersDto = photographers.Select(p => p.ToPhotographerDto());
            return Ok(photographersDto);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPhotographerById(int id)
        {
            var photographer = await _photographerRepository.GetPhotographerByIdAsync(id);
            if (photographer == null)
            {
                return NotFound("Photographer not found");
            }
            return Ok(photographer.ToPhotographerDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePhotographer([FromBody] UpdatePhotographerDto updatePhotographer, [FromRoute] int id)
        {
            var photographer = await _photographerRepository.UpdatePhotographerAsync(id, updatePhotographer);
            if (photographer == null)
            {
                return BadRequest("photographer does not exist!!");
            }

            return Ok(photographer.ToPhotographerDto());

        }

        [HttpPost]
        public async Task<IActionResult> PostPhotographer([FromBody] CreatePhotographerDto createPhotographer)
        {
            if (createPhotographer == null)
            {
                return BadRequest();
            }
            var photographer =await _photographerRepository.CreatePhotographerAsync( createPhotographer.ToPhotographerFromCreateDto());
            if (photographer==null)
            {
                return BadRequest();
            }   


            return Ok(photographer.ToPhotographerDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePhotographer(int id)
        {
            var photographer = await _photographerRepository.DeletePhotographerAsync(id);
            if (photographer == null)
            {
                return BadRequest("Photographer does not exist");
            }
            return Ok("Photographer account successfully deleted");
        }
    }
}
