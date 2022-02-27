using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.RateLimiting.Strategies
{
    internal class IpRateLimit : IRateLimiterStrategy
    {
        public ValueTask<bool> IsAllowed(object context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
