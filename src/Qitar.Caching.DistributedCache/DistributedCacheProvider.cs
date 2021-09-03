using Microsoft.Extensions.Caching.Distributed;
using Qitar.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Caching.DistributedCache
{
    public class DistributedCacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ISerializer _serializer;

        public DistributedCacheProvider(IDistributedCache distributedCache, ISerializer serializer)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public async ValueTask Add<T>(string key, T obj, int cacheTime, CancellationToken cancellationToken = default)
        {
            var cacheOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = new TimeSpan(0, cacheTime, 0)
            };

            var value = await _serializer.Serialize(obj, cancellationToken).ConfigureAwait(false);

            await _distributedCache.SetStringAsync(key, value, cacheOptions, cancellationToken).ConfigureAwait(false);
        }

        public async  ValueTask<T> Get<T>(string key, CancellationToken cancellationToken = default)
        {
            var value = await _distributedCache.GetStringAsync(key, cancellationToken).ConfigureAwait(false);

            return await _serializer.Deserialize<T>(value, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<bool> IsSet(string key, CancellationToken cancellationToken = default)
        {
            var value = await _distributedCache.GetAsync(key, cancellationToken).ConfigureAwait(false);

            return value == null || value.Length == 0 ;
        }

        public async ValueTask Remove(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(key, cancellationToken).ConfigureAwait(false);
        }
    }
}
