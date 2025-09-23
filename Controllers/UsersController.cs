using boardgameStats.Services;
using Microsoft.AspNetCore.Mvc;

namespace boardgameStats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;
     
        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }
     
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _usersService.GetUsers();
     
            return Ok(result);
        }
    }
}
