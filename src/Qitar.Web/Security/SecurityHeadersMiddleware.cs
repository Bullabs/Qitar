using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Qitar.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qitar.Web.Security
{
    public class SecurityHeadersMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            AddHeaderIfNotExists(context, "X-Content-Type-Options", "nosniff");
            AddHeaderIfNotExists(context, "X-XSS-Protection", "1; mode=block");
            AddHeaderIfNotExists(context, "X-Frame-Options", "SAMEORIGIN");

            await next.Invoke(context).ConfigureAwait(false);

        }
        private void AddHeaderIfNotExists(HttpContext context, string key, string value)
        {
            context.Response.Headers.AddIfNotContains(new KeyValuePair<string, StringValues>(key, value));
        }
    }
}
