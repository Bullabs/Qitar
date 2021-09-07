using Microsoft.AspNetCore.Http;
using Qitar.Metrics;
using Qitar.Utils;
using Qitar.Web.Extensions;
using System.Threading.Tasks;

namespace Qitar.Web.Metrics
{
    public class RequestErrorMiddleware : IMiddleware
    {
        private readonly IMetrics _metrics;

        public RequestErrorMiddleware(IMetrics metrics)
        {
            _metrics = metrics.NotNull();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context).ConfigureAwait(false);

            if (!context.Response.IsSuccessfulResponse())
            {
                await _metrics.Counter($"request-error-{context.Response.StatusCode}", 1, context.RequestAborted).ConfigureAwait(false);
            }
        }
    }
}
