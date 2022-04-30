using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Qitar.Web.Exceptions;
using Qitar.Web.Metrics;
using Qitar.Web.Security;
using Qitar.Web.Swagger;
using Qitar.Web.Tenancy;
using Qitar.Web.Tracing;

namespace Qitar.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseQitarWeb(this IApplicationBuilder app, bool tracingSupport = true, bool securityHeadersSupport = true, bool exceptionHandlingSupport = true, bool metricsSupport = false, bool tenancySupport = false)
        {
            if(tracingSupport)
            {
                app.UseTracing();
            }
            if (securityHeadersSupport)
            {
                app.UseSecurityHeaders();
            }
            if (exceptionHandlingSupport)
            {
                app.UseExceptionHandling();
            }
            if (metricsSupport)
            {
                app.UseTenancy();
            }
            if (tenancySupport)
            {
                app.UseTenancy();
            }

            return app;
        }

        internal static IApplicationBuilder UseTracing(this IApplicationBuilder app)
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

        internal static IApplicationBuilder UseMetrics(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestTimerMiddleware>();
            return app.UseMiddleware<RequestErrorMiddleware>();
        }

        internal static IApplicationBuilder UseTenancy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenancyMiddleware>();
        }

        internal static IApplicationBuilder UseSwaggerAPI(this IApplicationBuilder app)
        {
            var resolver = app.ApplicationServices.GetService<ISwaggerHtmlResolver>();

            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.IndexStream = () => resolver.Resolver();
            });
            return app;
        }
    }
}
