using Microsoft.AspNetCore.Builder;
using Qitar.Web.Exceptions;
using Qitar.Web.Security;
using Qitar.Web.Tenancy;
using Qitar.Web.Tracing;

namespace Qitar.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseQitarWeb(this IApplicationBuilder app, bool correlationIdSupport = true, bool securityHeadersSupport = true, bool exceptionHandlingSupport = true, bool tenancySupport = false)
        {
            if(correlationIdSupport)
            {
                app.UseCorrelationId();
            }
            if (securityHeadersSupport)
            {
                app.UseSecurityHeaders();
            }
            if (exceptionHandlingSupport)
            {
                app.UseExceptionHandling();
            }
            if (tenancySupport)
            {
                app.UseTenancy();
            }

            return app;
        }

        internal static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }

        internal static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SecurityHeadersMiddleware>();
        }

        internal static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        internal static IApplicationBuilder UseTenancy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenancyMiddleware>();
        }
    }
}
