using Qitar.Caching;
using Qitar.Tenancy.Store;
using Qitar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy
{
    public class TenantResolver : ITenantResolver
    {
        private readonly ITenantStore _store;
        private readonly IEnumerable<ITenantStrategy> _strategies;
        private readonly ICacheService _cache;

        public TenantResolver(IEnumerable<ITenantStrategy> strategies, ITenantStore store, ICacheService cache)
        {
            _store = store.NotNull();
            _strategies = strategies.NotNull().OrderByDescending(s => s.Priority);
            _cache = cache.NotNull();
        }

        public async ValueTask<ITenantInfo> Resolve(object context, CancellationToken cancellationToken = default)
        {
            ITenantInfo tenantInfo = null;

            foreach (var strategy in _strategies)
            {
                var identfier = await strategy.GetIdentifier(context, cancellationToken).ConfigureAwait(false);

                if (!string.IsNullOrWhiteSpace(identfier))
                {
                    tenantInfo = await _cache.GetOrSet($"tenant-{identfier}", GetTenante(_store, identfier, cancellationToken)).ConfigureAwait(false);
                }

                break;
            }

            return tenantInfo;
        }

        private Func<ValueTask<ITenantInfo>> GetTenante(ITenantStore store, string identfier, CancellationToken cancellationToken)
        {
            return async () =>
            {
                return await store.GetByIdentifier(identfier, cancellationToken).ConfigureAwait(false);
            };
        }
    }
}s
