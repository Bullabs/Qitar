using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Qitar.Tenancy;
using Qitar.Utils;
using System.Threading.Tasks;

namespace Qitar.Web.Tenancy
{
    internal class TenancyMiddleware : IMiddleware
    {
        private readonly ITenantResolver _tenantResolver;

        public TenancyMiddleware(ITenantResolver tenantResolver)
        {
            _tenantResolver = tenantResolver.NotNull();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tenateContext = context.RequestServices.GetRequiredService<ITenantContext>();

            if(tenateContext.CurrentTenant == null)
            {
                var tenate = await _tenantResolver.Resolve(context).ConfigureAwait(false);
                tenateContext.CurrentTenant = tenate;
            }

            await next.Invoke(context).ConfigureAwait(false);
        }
    }
}
