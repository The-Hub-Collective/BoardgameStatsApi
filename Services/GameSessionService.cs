namespace boardgameStats.Services
{
    public interface IGameSessionService 
    {
        // Define methods related to game session management here
    }

    public class GameSessionService : IGameSessionService
     {
          private ILogger<GameSessionService> _logger;
          private IDatabaseService _databaseService;
     
          public GameSessionService(IDatabaseService databaseService, ILogger<GameSessionService> logger )
          {
               _logger = logger;
               _databaseService = databaseService;
          }
     }
}
