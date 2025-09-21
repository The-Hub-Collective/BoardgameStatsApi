using Microsoft.AspNetCore.Mvc;
using static boardgameStats.Services.NemesisService;

namespace boardgame_stats.Controllers
{
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
            [Route("nemesis")]
            public async Task<ActionResult> Get()
            {
               var result = await _nemesisService.GetNemesisDeaths();
     
               return Ok(result);
            }
    }
}
