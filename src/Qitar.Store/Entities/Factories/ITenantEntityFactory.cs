using Qitar.Tenancy;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public interface ITenantEntityFactory
    {
        ValueTask<TenantEntity> CreateTenant(Tenant obj);
    }
}
