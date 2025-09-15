using boardgameStats.Options;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace boardgameStats.Services
{
    public interface IDatabaseService
    {
        public Task<IEnumerable<T>> QueryAsync<T>( string sql, object parameters );
    }
    public class DatabaseService : IDatabaseService
    {
        private readonly ILogger<DatabaseService> _logger;
        private readonly string _connectionString;
        private readonly IOptions<DatabaseOptions> _options;


        public DatabaseService( ILogger<DatabaseService> logger, IOptions<DatabaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
            _logger = logger;
            _options = options;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>( string sql, object parameters )
        {
            _logger.LogInformation( "Connectionstring : " + _connectionString );

            try
            {
                using var connection = new SqlConnection( _connectionString );
                await connection.OpenAsync();
                return await connection.QueryAsync<T>( sql, parameters );
            }
            catch ( Exception ex )
            {
                _logger.LogError( "Error occured", ex );
                throw ex;
            }
        }
    }
}
