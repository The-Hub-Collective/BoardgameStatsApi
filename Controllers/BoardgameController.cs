using boardgameStats.Classes;
using boardgameStats.Services;
using Microsoft.AspNetCore.Mvc;
using static boardgameStats.Services.BoardgameService;

namespace boardgame_stats.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardgameController : ControllerBase
{
    private readonly ILogger<BoardgameController> _logger;
    private readonly IBoardgameService _boardgameService;

    public BoardgameController(ILogger<BoardgameController> logger, IBoardgameService boardgameService)
    {
        _logger = logger;
        _boardgameService = boardgameService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _boardgameService.GetBoardgames();

        return Ok(result);
    }
}
