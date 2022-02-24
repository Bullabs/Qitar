using Qitar.Store.Connections;
using Snowflake.Data.Client;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Snowflake
{
    public class SnowflakeDatabaseConnectionFactory : ISqlConnectionFactory
    {
        public async ValueTask<IDbConnection> OpenConnection(string connectionString, CancellationToken cancellationToken)
        {
            var connection = new SnowflakeDbConnection() { ConnectionString = connectionString };
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            return connection;

        }
    }
}