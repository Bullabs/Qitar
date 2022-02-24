using Npgsql;
using Qitar.Store.Connections;
using Qitar.Utils;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Postgres
{
    public class PostgresDatabaseConnectionFactory : ISqlConnectionFactory
    {
        public async ValueTask<IDbConnection> OpenConnection(string connectionString, CancellationToken cancellationToken)
        {
            connectionString.NotNull();

            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            return connection;
        }
    }
}