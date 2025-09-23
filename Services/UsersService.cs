using boardgameStats.Classes;

namespace boardgameStats.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<Users>> GetUsers();
    }

        public class UsersServiceImpl : IUsersService
        {
            private ILogger<UsersServiceImpl> _logger;
            private IDatabaseService _databaseService;
     
            public UsersServiceImpl(IDatabaseService databaseService, ILogger<UsersServiceImpl> logger )
            {
                _logger = logger;
                _databaseService = databaseService;
            }
     
            public async Task<IEnumerable<Users>> GetUsers()
            {
                var result = await _databaseService.QueryAsync<Users>( "select * from Users", null );
     
                return result;
            }
        }
}
