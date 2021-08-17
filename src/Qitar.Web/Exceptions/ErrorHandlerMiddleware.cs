using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Qitar.Serialization;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.Exceptions
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ISerializer _serializer;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ISerializer serializer, ILogger<ErrorHandlerMiddleware> logger)
        {
            _serializer = serializer;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                var ct  = context?.RequestAborted ?? CancellationToken.None;

                await HandleErrorAsync(context, exception,ct).ConfigureAwait(false);
            }
        }
        private async ValueTask HandleErrorAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            context.Response.Body = await _serializer.SerializeStreamAsync(exception, cancellationToken).ConfigureAwait(false);
        }
    }
}
