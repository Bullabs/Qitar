using Qitar.Caching;
using Qitar.Logging;
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
        private readonly ILogger _logger;

        public TenantResolver(IEnumerable<ITenantStrategy> strategies, ITenantStore store, ICacheService cache, ILogger logger)
        {
            _store = store.NotNull();
            _strategies = strategies.NotNull().OrderByDescending(s => s.Priority);
            _cache = cache.NotNull();
            _logger = logger.NotNull();
        }

        public async ValueTask<ITenant> Resolve(object context, CancellationToken cancellationToken = default)
        {
            context.NotNull();

            ITenant tenantInfo = null;

            _logger.Information("Resolving tenant");

            foreach (var strategy in _strategies)
            {
                var identfier = await strategy.GetIdentifier(context, cancellationToken).ConfigureAwait(false);

                if (!string.IsNullOrWhiteSpace(identfier))
                {
                    tenantInfo = await _cache.GetOrSet($"TENANT:{identfier}", GetTenante(_store, identfier, cancellationToken)).ConfigureAwait(false);
                }

                if(tenantInfo is not null)
                {
                    break;
                }
            }

            return tenantInfo;
        }

        private Func<ValueTask<ITenant>> GetTenante(ITenantStore store, string identfier, CancellationToken cancellationToken)
        {
            return async () =>
            {
                return await store.GetByIdentifier(identfier, cancellationToken).ConfigureAwait(false);
            };
        }
    }
}
