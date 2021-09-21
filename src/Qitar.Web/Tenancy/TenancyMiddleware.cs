using Microsoft.AspNetCore.Http;
using Qitar.Tenancy;
using Qitar.Utils;
using System.Threading.Tasks;

namespace Qitar.Web.Tenancy
{
    public class TenancyMiddleware : IMiddleware
    {
        private readonly ITenantResolver _tenantResolver;

        public TenancyMiddleware(ITenantResolver tenantResolver)
        {
            _tenantResolver = tenantResolver.NotNull();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tenate = await _tenantResolver.Resolve(context).ConfigureAwait(false);
            await next.Invoke(context).ConfigureAwait(false);
        }
    }
}
