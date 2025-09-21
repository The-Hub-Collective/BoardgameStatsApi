using boardgameStats.Models;

namespace boardgameStats.Services
{
    public class NemesisService
    {
        public interface INemesisService 
        {
               public Task<IEnumerable<NemesisDeathTypes>> GetNemesisDeaths();
        }

        public class NemesisServiceImp : INemesisService
        {
            private ILogger<NemesisService> _logger;
            private IDatabaseService _databaseService;

            public NemesisServiceImp(IDatabaseService databaseService, ILogger<NemesisService> logger )
            {
                _logger = logger;
                _databaseService = databaseService;
            }

            public async Task<IEnumerable<NemesisDeathTypes>> GetNemesisDeaths()
            {
                var result = await _databaseService.QueryAsync<NemesisDeathTypes>( "select * from NemesisDeaths", null );
                return result;
            }
        }
    }
}
