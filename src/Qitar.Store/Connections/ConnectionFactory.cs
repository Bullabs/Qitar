using Microsoft.Data.Sqlite;
using MySqlConnector;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Qitar.Connections;
using Snowflake.Data.Client;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Connections
{
    public class ConnectionFactory : IConnectionFactory
    {
        public ValueTask<IDbConnection> Create(int connectionType, string connectionString, CancellationToken cancellationToken)
        {
            return (ConnectionType) connectionType switch
            {
                ConnectionType.SqlConnection => new ValueTask<IDbConnection>(new SqlConnection(connectionString)),
                ConnectionType.MySqlConnection => new ValueTask<IDbConnection>(new MySqlConnection(connectionString)),
                ConnectionType.NpgsqlConnection => new ValueTask<IDbConnection>(new NpgsqlConnection(connectionString)),
                ConnectionType.OracleConnection => new ValueTask<IDbConnection>(new OracleConnection(connectionString)),
                ConnectionType.SQLiteConnection => new ValueTask<IDbConnection>(new SqliteConnection(connectionString)),
                ConnectionType.SnowflakeDbConnection => new ValueTask<IDbConnection>(new SnowflakeDbConnection() { ConnectionString = connectionString }),
                _ => new ValueTask<IDbConnection>(new SqlConnection(connectionString)),
            };
        }
    }
}
