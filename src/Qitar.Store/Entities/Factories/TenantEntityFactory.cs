using Qitar.Mapping;
using Qitar.Tenancy;
using Qitar.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public class TenantEntityFactory : IEntityFactory<Tenant,TenantEntity>
    {
        private readonly IMapper _mapper;

        public TenantEntityFactory(IMapper mapper)
        {
            _mapper = mapper.NotNull();
        }

        public async ValueTask<TenantEntity> CreateEntity(Tenant obj, CancellationToken cancellationToken = default)
        {
            return await _mapper.Map<TenantEntity>(obj).ConfigureAwait(false);
        }
    }
}
