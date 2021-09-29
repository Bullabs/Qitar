using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Store
{
    public class TenantStore : ITenantStore
    {
        public ValueTask<ITenant> GetById(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ITenant> GetByIdentifier(string Identifier, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
