using boardgameStats.Classes;
using boardgameStats.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace boardgameStats.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<Users>> GetUsers();
        public Task<IEnumerable<Users>> GetUser( int id);
        public Task CreateUser( Users request );
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

        public async Task<IEnumerable<Users>> GetUser(int id)
        {
            var user = await _databaseService.QueryAsync<Users>( "select * from Users where Id = @Id", new { Id = id } );
            
            return user;
        }

        public async Task CreateUser(Users newUser)
        {
            var sql = "INSERT INTO Users (Username, Password, Email, CreatedAt) " +
                      "VALUES (@Username, @Password, @Email, @CreatedAt); " +
                      "SELECT * FROM Users WHERE Id = SCOPE_IDENTITY();";

            newUser.CreatedAt = DateTime.UtcNow;
            var parameters = new
            {
                newUser.Username,
                newUser.Password,
                newUser.Email,
                newUser.CreatedAt,
            };

            await _databaseService.QueryAsync<Users>(sql, parameters);
        }
    }
}
