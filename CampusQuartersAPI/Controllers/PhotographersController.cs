using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Photographer;
using CampusQuartersAPI.Mappers;
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
            var photographers = _dataContext.Photographers
               .ToList();
            var photographersDto = photographers.Select(p => p.ToPhotographerDto());
            return Ok(photographersDto);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPhotographerById(int id)
        {
            var photographer = _dataContext.Photographers.FirstOrDefault(p => p.Id == id);
            if (photographer == null)
            {
                return NotFound("Photographer not found");
            }
            return Ok(photographer.ToPhotographerDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePhotographer([FromBody] UpdatePhotographerDto updatePhotographer, [FromRoute] int id)
        {
            var photographer = _dataContext.Photographers.FirstOrDefault(p => p.Id == id);
            if (photographer == null)
            {
                return BadRequest("photographer does not exist!!");
            }
            else
            {
                photographer.Name = updatePhotographer.Name;
                photographer.Surname = updatePhotographer.Surname;
                photographer.CellNumber = updatePhotographer.CellNumber;
                _dataContext.SaveChanges();

                return Ok(photographer.ToPhotographerDto());
            }
        }

        [HttpPost]
        public IActionResult PostPhotographer([FromBody] CreatePhotographerDto createPhotographer)
        {
            if (createPhotographer == null)
            {
                return BadRequest();
            }
            var photographer = createPhotographer.ToPhotographerFromCreateDto();

            _dataContext.Photographers.Add(photographer);
            _dataContext.SaveChanges();

            return Ok(photographer.ToPhotographerDto());
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
            
            _dataContext.Photographers.Remove(photographer);
            _dataContext.Account.Remove(photographer.Account);
            _dataContext.SaveChanges();
            return Ok("Photographer account successfully deleted");
        }
    }
}
