using CampusQuartersAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CampusQuartersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly CampusQuartersDataContext _context;

        public AccountsController(CampusQuartersDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAccounts() 
        {
            var accounts = _context.Account.ToList();
           
            return Ok(accounts);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAccount(int id) 
        {
            var account = _context.Account.FirstOrDefault(x => x.Id == id);
            if(account == null)
            {
                return NotFound("Account does not exist");
            }
            return Ok(account);
        }
    }
}
