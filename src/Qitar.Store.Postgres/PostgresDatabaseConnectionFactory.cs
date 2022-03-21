using Npgsql;
using Qitar.Logging;
using Qitar.Store.Connections;
using Qitar.Utils;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Postgres
{
    public class PostgresDatabaseConnectionFactory : ISqlConnectionFactory
    {
        private readonly ILogger _logger;

        public PostgresDatabaseConnectionFactory(ILogger logger)
        {
            _logger = logger.NotNull();
        }

        public async ValueTask<IDbConnection> OpenConnection(string connectionString, CancellationToken cancellationToken)
        {
            connectionString.NotNull();

            _logger.Information("Opening new SQL DB connection");

            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            return connection;
        }
    }
}