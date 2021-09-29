using Microsoft.Extensions.Options;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Caching
{
    public class CacheService : ICacheService
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly ICacheKeyNormalizer _cacheKeyNormalizer;
        private readonly CacheOptions _options;

        public CacheService(ICacheProvider cacheProvider, ICacheKeyNormalizer cacheKeyNormalizer, IOptions<CacheOptions> options)
        {
            _cacheProvider = cacheProvider.NotNull();
            _cacheKeyNormalizer = cacheKeyNormalizer.NotNull();
            _options = options.Value;
        }

        public async ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, CancellationToken cancellationToken = default)
        {
            var normalizedKey = _cacheKeyNormalizer.NormalizeKey(key);

            return await GetOrSet(normalizedKey, acquireAsync, _options.DefaultCacheTime, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, int cacheTime, CancellationToken cancellationToken = default)
        {
            var normalizedKey = _cacheKeyNormalizer.NormalizeKey(key);

            var data = await _cacheProvider.Get<T>(normalizedKey, cancellationToken).ConfigureAwait(false);

            if (data != null)
            {
                return data;
            }

            var result = await acquireAsync();
            await _cacheProvider.Add(normalizedKey, result, cacheTime, cancellationToken).ConfigureAwait(false);

            return result;

        }

        public async ValueTask RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            var normalizedKey = _cacheKeyNormalizer.NormalizeKey(key);

            await  _cacheProvider.Remove(normalizedKey, cancellationToken).ConfigureAwait(false);
        }
    }
}
