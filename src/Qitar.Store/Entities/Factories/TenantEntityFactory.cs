using Qitar.Mapping;
using Qitar.Tenancy;
using System;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public class TenantEntityFactory : ITenantEntityFactory
    {
        private readonly IMapper _mapper;

        public TenantEntityFactory(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ValueTask<TenantEntity> CreateTenant(Tenant obj)
        {
            return new ValueTask<TenantEntity>(_mapper.Map<TenantEntity>(obj));
        }
    }
}
