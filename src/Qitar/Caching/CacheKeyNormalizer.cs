using Microsoft.Extensions.Options;
using Qitar.Tenancy;
using Qitar.Utils;

namespace Qitar.Caching
{
    public class CacheKeyNormalizer : ICacheKeyNormalizer
    {
        private readonly ICurrentTenant _tenant;
        private readonly CacheOptions _options;

        public CacheKeyNormalizer(ICurrentTenant tenant, IOptions<CacheOptions> options)
        {
            _tenant = tenant.NotNull();
            _options = options.Value;
        }

        public string NormalizeKey(string key)
        {
            var normalizedKey = $"K:{_options.KeyPrefix}{key}";

            if(_tenant.Id.HasValue)
            {
                normalizedKey = $"T:{_tenant.Id.Value},{normalizedKey}";
            }

            return normalizedKey;
        }
    }
}
