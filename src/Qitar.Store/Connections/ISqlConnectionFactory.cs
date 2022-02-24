using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Connections
{
    public interface ISqlConnectionFactory
    {
        ValueTask<IDbConnection> OpenConnection(string connectionString,CancellationToken cancellationToken);
    }
}
