using Oracle.ManagedDataAccess.Client;
using Qitar.Store.Connections;
using Qitar.Utils;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Oracle
{
    public class OracleDatabaseConnectionFactory : ISqlConnectionFactory
    {
        public async ValueTask<IDbConnection> OpenConnection(string connectionString, CancellationToken cancellationToken)
        {
            connectionString.NotNull();

            var connection = new OracleConnection(connectionString);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            return connection;
        }
    }
}