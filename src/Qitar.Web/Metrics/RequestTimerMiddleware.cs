using Microsoft.AspNetCore.Http;
using Qitar.Metrics;
using Qitar.Utils;
using System.Threading.Tasks;

namespace Qitar.Web.Metrics
{  
    public class RequestTimerMiddleware : IMiddleware
    {
        private readonly IMetrics _metrics;

        public RequestTimerMiddleware(IMetrics metrics)
        {
            _metrics = metrics.NotNull();
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            return next(context);
        }
    }
}
