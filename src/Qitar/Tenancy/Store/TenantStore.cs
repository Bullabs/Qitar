using Microsoft.Extensions.Options;
using Qitar.Caching;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Store
{
    public class TenantStore : ITenantStore
    {
        private readonly ICacheService _cacheService;
        private readonly ITenantStoreProvider _tenantStoreProvider;
        private readonly TenantOptions _options;

        public TenantStore(ITenantStoreProvider tenantStoreProvider,IOptions<TenantOptions> options,ICacheService cacheService)
        {
            _tenantStoreProvider = tenantStoreProvider.NotNull();
            _options = options.Value.NotNull();
            _cacheService = cacheService.NotNull();
        }

        public async ValueTask<ITenant> GetById(object id, CancellationToken cancellationToken = default)
        {
            return await _cacheService.GetOrSet($"TENANT:{id}"
            , async () => await _tenantStoreProvider.GetById(id, cancellationToken).ConfigureAwait(false)
            , _options.CacheTime, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<ITenant> GetByIdentifier(string Identifier, CancellationToken cancellationToken = default)
        {
            return await _cacheService.GetOrSet($"TENANT:{Identifier}"
            , async () => await _tenantStoreProvider.Find((t)=> t.Identifier == Identifier, cancellationToken).ConfigureAwait(false)
            , _options.CacheTime, cancellationToken).ConfigureAwait(false); 

        }
    }
}
