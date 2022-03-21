using Microsoft.Extensions.Options;
using Qitar.Logging;
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
        private readonly ILogger _logger;

        public CacheService(ICacheProvider cacheProvider, ICacheKeyNormalizer cacheKeyNormalizer, IOptions<CacheOptions> options, ILogger logger)
        {
            _cacheProvider = cacheProvider.NotNull();
            _cacheKeyNormalizer = cacheKeyNormalizer.NotNull();
            _options = options.Value;
            _logger = logger.NotNull();
        }

        public async ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, CancellationToken cancellationToken = default)
        {

            return await GetOrSet(key, acquireAsync, _options.DefaultCacheTime, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, int cacheTime, CancellationToken cancellationToken = default)
        {
            var normalizedKey = _cacheKeyNormalizer.NormalizeKey(key);

            var isSet = await _cacheProvider.IsSet(normalizedKey, cancellationToken).ConfigureAwait(false);

            if (isSet)
            {                
                var result =  await _cacheProvider.Get<T>(normalizedKey, cancellationToken).ConfigureAwait(false);

                _logger.Trace($"Cache hit. key={key} valueType={result}");

                return result;
            }
            else
            {                
                var result = await acquireAsync();

                _logger.Trace($"Attempting to add a new entry to the cache. key={key} valueType={result}.");

                await _cacheProvider.Add(normalizedKey, result, cacheTime, cancellationToken).ConfigureAwait(false);
                return result;
            }
        }

        public async ValueTask RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            var normalizedKey = _cacheKeyNormalizer.NormalizeKey(key);

            await  _cacheProvider.Remove(normalizedKey, cancellationToken).ConfigureAwait(false);
        }
    }
}
