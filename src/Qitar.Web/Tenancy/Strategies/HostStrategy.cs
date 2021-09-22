using Microsoft.AspNetCore.Http;
using Qitar.Tenancy;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.Tenancy.Strategies
{
    public class HostStrategy : ITenantStrategy
    {
        public ValueTask<string> GetIdentifier(object context, CancellationToken cancellationToken = default)
        {
            if (context is not HttpContext httpContext)
            {
                throw new TenancyException(this.GetType().Name,
                    new ArgumentException($"\"{nameof(context)}\" type must be of type HttpContext", nameof(context)));
            }

            var host = httpContext.Request.Host;

            return new ValueTask<string>(host.Value);

        }
    }
}
