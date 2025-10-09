using boardgameStats.Services;
using Microsoft.AspNetCore.Mvc;

namespace boardgame_stats.Controllers
{

    [ApiController]
    [Route( "[controller]" )]
    public class GameSessionController : ControllerBase
    {
        private readonly ILogger<BoardgameController> _logger;
        private readonly IGameSessionService _gameSessionService;

        public GameSessionController( ILogger<BoardgameController> logger, IGameSessionService gameSessionService )
        {
            _logger = logger;
            _gameSessionService = gameSessionService;
        }
    }
}
