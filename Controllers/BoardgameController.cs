using boardgameStats.Classes;
using boardgameStats.Services;
using Microsoft.AspNetCore.Mvc;

namespace boardgame_stats.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardgameController : ControllerBase
{
    private readonly ILogger<BoardgameController> _logger;
    private readonly IDatabaseService _databaseService;

    public BoardgameController(ILogger<BoardgameController> logger, IDatabaseService databaseService)
    {
        _logger = logger;
        _databaseService = databaseService;
    }

    [HttpGet]
    public async Task<IEnumerable<Boardgames>> Get()
    {
        var result = await _databaseService.QueryAsync<Boardgames>( "select * from Boardgames", null );

        return result;
    }
}
