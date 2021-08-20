using Microsoft.AspNetCore.Builder;
using Qitar.Web.Exceptions;
using Qitar.Web.Security;
using Qitar.Web.Tenancy;
using Qitar.Web.Tracing;

namespace Qitar.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }

        public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SecurityHeadersMiddleware>();
        }

        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseTenancy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenancyMiddleware>();
        }
    }
}
