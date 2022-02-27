using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.RateLimiting.Strategies
{
    internal interface IRateLimiterStrategy
    {
        ValueTask<bool> IsAllowed(object context, CancellationToken cancellationToken = default);
    }
}
