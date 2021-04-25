using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Caching
{
    public interface ICacheService
    {
        ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, CancellationToken cancellationToken = default);
        ValueTask<T> GetOrSet<T>(string key, Func<ValueTask<T>> acquireAsync, int cacheTime, CancellationToken cancellationToken = default);
        ValueTask RemoveAsync(string key, CancellationToken cancellationToken = default);
    }
}
