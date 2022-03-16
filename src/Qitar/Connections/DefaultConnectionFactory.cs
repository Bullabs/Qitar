using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Connections
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        public ValueTask<IDbConnection> Create(string connectionType, string connectionString, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
