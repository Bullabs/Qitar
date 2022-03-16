using Qitar.Connections;
using Qitar.Utils;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Connections
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IEnumerable<ISqlConnectionFactory> _sqlConnections;

        public ConnectionFactory(IEnumerable<ISqlConnectionFactory> sqlConnections)
        {
            _sqlConnections = sqlConnections.NotNull();
        }

        public async ValueTask<IDbConnection> Create(string connectionType, string connectionString, CancellationToken cancellationToken)
        {
            var con = _sqlConnections.FirstOrDefault(con=> con.GetType().Name == connectionType);

            if(con == null)
            {
                throw new System.NullReferenceException("Connection Type is not found");
            }

            return await con.OpenConnection(connectionString, cancellationToken).ConfigureAwait(false);
        }
    }
}
