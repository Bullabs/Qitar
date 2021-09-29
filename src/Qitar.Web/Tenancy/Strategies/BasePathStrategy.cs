using Microsoft.AspNetCore.Http;
using Qitar.Tenancy;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.Tenancy.Strategies
{
    public class BasePathStrategy : ITenantStrategy
    {
        public ValueTask<string> GetIdentifier(object context, CancellationToken cancellationToken = default)
        {
            if (context is not HttpContext httpContext)
            {
                throw new TenancyException(this.GetType().Name,
                    new ArgumentException($"\"{nameof(context)}\" type must be of type HttpContext", nameof(context)));
            }

            var path = httpContext.Request.Path;

            var pathSegments = path.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (pathSegments.Length == 0)
            {
                return new ValueTask<string>(string.Empty);
            }

            return new ValueTask<string>(pathSegments[0]);
        }
    }
}
