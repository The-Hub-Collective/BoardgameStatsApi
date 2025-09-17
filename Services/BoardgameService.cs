using boardgameStats.Classes;

namespace boardgameStats.Services
{
    public class BoardgameService
    {
        public interface IBoardgameService
        {
            public Task<IEnumerable<Boardgames>> GetBoardgames();
        }

        public class BoardgamesService : IBoardgameService
        {
            private ILogger<BoardgamesService> _logger;
            private IDatabaseService _databaseService;

            public BoardgamesService(IDatabaseService databaseService, ILogger<BoardgamesService> logger )
            {
                _logger = logger;
                _databaseService = databaseService;
            }

            public async Task<IEnumerable<Boardgames>> GetBoardgames()
            {
                var result = await _databaseService.QueryAsync<Boardgames>( "select * from Boardgames", null );

                return result;
            }
        }

    }
}
