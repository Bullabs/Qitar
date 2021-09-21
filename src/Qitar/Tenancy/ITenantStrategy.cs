using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy
{
    public interface ITenantStrategy
    {
        ValueTask<string> GetIdentifier(object context, CancellationToken cancellationToken = default);
        int Priority => 0;
    }
}
