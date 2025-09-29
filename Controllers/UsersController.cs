using boardgameStats.Classes;
using boardgameStats.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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

            //timezone conversion
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            var convertedResult = result.Select( user => {
                user.CreatedAt = TimeZoneInfo.ConvertTimeFromUtc( user.CreatedAt, timeZone );
                if ( user.UpdatedAt != null )
                {
                    user.UpdatedAt = TimeZoneInfo.ConvertTimeFromUtc( ( DateTime )  user.UpdatedAt , timeZone );
                }
                return user;
            } );

            return Ok( convertedResult );
        }

        //post request
        [HttpPost]
        public async Task<ActionResult> AddUser( [FromBody] Users user )
        {
            user.CreatedAt = DateTime.UtcNow;

            var result = await _usersService.CreateUserAsync( user );

            return Ok( result );
        }
    }
}
