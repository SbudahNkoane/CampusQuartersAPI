using CampusQuartersAPI.Data;
using CampusQuartersAPI.Dtos.Administrator;
using CampusQuartersAPI.Mappers;
using DomainLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorRepository _administratorRepository;

        public AdministratorsController(CampusQuartersDataContext dataContext, IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            var admins = await _administratorRepository.GetAllAdministratorsAsync();
            if (admins == null)
            {
                return BadRequest();
            }
            var adminsDto = admins.Select(a => a.ToAdministratorDto());
            return Ok(adminsDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _administratorRepository.GetAdministratorByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin.ToAdministratorDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAdministrator([FromBody] UpdateAdministratorDto updateAdministrator, [FromRoute] int id)
        {
            var admin = await _administratorRepository.UpdateAdministratorAsync(id, updateAdministrator);
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin.ToAdministratorDto());
        }
        [HttpPost]
        public async Task<IActionResult> PostAdmin([FromBody] CreateAdministratorDto createAdministrator)
        {
            var administrator = await _administratorRepository
                                                    .CreateAdministratorAsync(createAdministrator.ToAdministratorFromCreateDto());


            return Ok(administrator.ToAdministratorDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _administratorRepository.DeleteAdministratorAsync(id);
            if (admin == null)
            {
                return BadRequest("Administrator does not exist");
            }
            return Ok("Administrator account successfully deleted");
        }
    }
}
