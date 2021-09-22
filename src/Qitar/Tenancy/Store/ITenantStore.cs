using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Store
{
    public interface ITenantStore
    {
        ValueTask<ITenant> GetById(object id, CancellationToken cancellationToken = default);
        ValueTask<ITenant> GetByIdentifier(string Identifier, CancellationToken cancellationToken = default);
    }
}
