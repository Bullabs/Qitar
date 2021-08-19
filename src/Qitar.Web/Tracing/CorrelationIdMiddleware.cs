using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Qitar.Tracing;
using System.Threading.Tasks;

namespace Qitar.Web.Tracing
{
    public class CorrelationIdMiddleware : IMiddleware
    {
        private readonly ICorrelationIdProvider _correlationIdProvider;
        private readonly CorrelationIdOptions _options;

        public CorrelationIdMiddleware(ICorrelationIdProvider correlationIdProvider, IOptions<CorrelationIdOptions> options)
        {
            _correlationIdProvider = correlationIdProvider;
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var correlationId = _correlationIdProvider.Get();

            try
            {
                await next(context).ConfigureAwait(false);
            }
            finally
            {
                SetCorrelationId(context, _options, correlationId);
            }
        }

        private void SetCorrelationId(HttpContext context, CorrelationIdOptions options, string correlationId)
        {
            if (context.Response.HasStarted)
            {
                return;
            }

            if (!options.SetResponseHeader)
            {
                return;
            }

            if (context.Response.Headers.ContainsKey(options.HttpHeaderName))
            {
                return;
            }

            context.Response.Headers[options.HttpHeaderName] = correlationId;
        }
    }
}
