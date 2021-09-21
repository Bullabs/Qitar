using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy
{
    public interface ITenantResolver
    {
        ValueTask<ITenantInfo> Resolve(object context, CancellationToken cancellationToken = default);
    }
}
