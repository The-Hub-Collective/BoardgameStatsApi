using boardgameStats.Classes;
using boardgameStats.Models;

namespace boardgameStats.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<Users>> GetUsers();
        public Task<IReadOnlyList<Users>> CreateUserAsync( Users request );
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

        public async Task<IReadOnlyList<Users>> CreateUserAsync( Users newUser )
        {
            var sql = "INSERT INTO Users (Username, Password, Email, CreatedAt) " +
                      "VALUES (@Username, @Password, @Email, @CreatedAt); " +
                      "SELECT CAST(SCOPE_IDENTITY() as int);";

            var parameters = new
            {
                newUser.Username,
                newUser.Password,
                newUser.Email,
                newUser.CreatedAt,
            };

            var result = await _databaseService.QueryAsync<Users>( sql, parameters );
            return result.ToList();
        }
    }
}
