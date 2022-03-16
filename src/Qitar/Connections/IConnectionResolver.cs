using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Connections
{
    public interface IConnectionResolver
    {
        ValueTask<IDbConnection> Resolve(CancellationToken cancellationToken = default);
    }
}
