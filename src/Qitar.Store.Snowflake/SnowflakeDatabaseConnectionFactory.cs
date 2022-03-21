using Qitar.Logging;
using Qitar.Store.Connections;
using Qitar.Utils;
using Snowflake.Data.Client;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Snowflake
{
    public class SnowflakeDatabaseConnectionFactory : ISqlConnectionFactory
    {
        private readonly ILogger _logger;

        public SnowflakeDatabaseConnectionFactory(ILogger logger)
        {
            _logger = logger.NotNull();
        }


        public async ValueTask<IDbConnection> OpenConnection(string connectionString, CancellationToken cancellationToken)
        {
            connectionString.NotNull();

            _logger.Information("Opening new SQL DB connection");

            var connection = new SnowflakeDbConnection() { ConnectionString = connectionString };
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            return connection;

        }
    }
}