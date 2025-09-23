using boardgameStats.Services;
using Microsoft.AspNetCore.Mvc;

namespace boardgame_stats.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class NemesisController : ControllerBase
    {
        private readonly ILogger<NemesisController> _logger;
        private readonly INemesisService _nemesisService;
     
        public NemesisController(ILogger<NemesisController> logger, INemesisService nemesisService)
        {
            _logger = logger;
            _nemesisService = nemesisService;
        }
     
        [HttpGet]
        [Route("deaths")]
        public async Task<ActionResult> Get()
        {
            var result = await _nemesisService.GetNemesisDeaths();
     
            return Ok(result);
        }
    }
}
