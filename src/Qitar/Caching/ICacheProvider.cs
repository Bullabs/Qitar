using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Caching
{
    public interface ICacheProvider
    {
        ValueTask<T> Get<T>(string key, CancellationToken cancellationToken = default);
        ValueTask Add<T>(string key, T obj, int cacheTime, CancellationToken cancellationToken = default);
        ValueTask<bool> IsSet(string key, CancellationToken cancellationToken = default);
        ValueTask Remove(string key, CancellationToken cancellationToken = default);
    }
}
