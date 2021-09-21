using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy
{
    public interface ITenantResolver
    {
        ValueTask<ITenant> Resolve(object context, CancellationToken cancellationToken = default);
    }
}
