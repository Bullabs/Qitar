using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Store
{
    public interface ITenantStoreProvider 
    {
        ValueTask<ITenant> GetById(object id, CancellationToken cancellationToken = default);
        ValueTask<ITenant> Find(Expression<Func<ITenant, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
