using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Connections
{
    public interface IConnectionFactory
    {
        ValueTask<IDbConnection> Create(int connectionType, string connectionString, CancellationToken cancellationToken);
    }
}
