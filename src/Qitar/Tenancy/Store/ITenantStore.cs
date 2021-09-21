using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Store
{
    public interface ITenantStore
    {
        ValueTask<ITenantInfo> GetById(object id, CancellationToken cancellationToken = default);
        ValueTask<ITenantInfo> GetByIdentifier(string Identifier, CancellationToken cancellationToken = default);
    }
}
