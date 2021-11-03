using Microsoft.AspNetCore.Http;

namespace Qitar.Web.Extensions
{
    internal static class HttpContextExtensions
    {
        public static bool IsSuccessfulResponse(this HttpResponse httpResponse)
        {
            return httpResponse.StatusCode < StatusCodes.Status400BadRequest;
        }

        public static void SetTenantInfo<T>(this HttpContext httpContext, T tenantInfo)
        {
        }
    }
}