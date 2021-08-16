using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Caching
{
    public class CacheService : ICacheService
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly CacheOptions _options;

        public CacheService(ICacheProvider cacheProvider, IOptions<CacheOptions> options)
        {
            _cacheProvider = cacheProvider ?? throw new ArgumentNullException(nameof(cacheProvider));
            _options = options.Value;
        }

        public async ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, CancellationToken cancellationToken = default)
        {
            return await GetOrSet(key, acquireAsync, _options.DefaultCacheTime, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, int cacheTime, CancellationToken cancellationToken = default)
        {
            var data = await _cacheProvider.Get<T>(key, cancellationToken).ConfigureAwait(false);

            if (data != null)
            {
                return data;
            }

            var result = await acquireAsync();
            await _cacheProvider.Add(key, result, cacheTime, cancellationToken).ConfigureAwait(false);

            return result;

        }

        public ValueTask RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
