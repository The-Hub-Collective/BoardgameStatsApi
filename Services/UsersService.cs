using boardgameStats.Classes;
using boardgameStats.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace boardgameStats.Services
{
    public interface IUsersService
    {
        public Task<IEnumerable<Users>> GetUsers();
        public Task<IEnumerable<Users>> GetUser( int id);
        public Task<int> CreateUser( UsersCreateRequest request );
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

        public async Task<int> CreateUser(UsersCreateRequest newUser)
        {
            var sql = "INSERT INTO Users (Username, Password, Email, CreatedAt) " +
                      "VALUES (@Username, @Password, @Email, @CreatedAt); " +
                      "SELECT * FROM Users WHERE Id = SCOPE_IDENTITY();";


            var parameters = new
            {
                newUser.Username,
                newUser.Password,
                newUser.Email,
                CreatedAt = DateTime.UtcNow
            };

            var id = await _databaseService.QueryAsync<int>(sql, parameters);
            return id.FirstOrDefault();
        }
    }
}
