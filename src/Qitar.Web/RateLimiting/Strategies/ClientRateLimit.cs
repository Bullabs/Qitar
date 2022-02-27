using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.RateLimiting.Strategies
{
    internal class ClientRateLimit : IRateLimiterStrategy
    {
        public ValueTask<bool> IsAllowed(object context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
