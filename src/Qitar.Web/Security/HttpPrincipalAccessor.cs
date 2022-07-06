using Microsoft.AspNetCore.Http;
using Qitar.Security;
using Qitar.Utils;
using System.Security.Claims;


namespace Qitar.Web.Security
{
    public class HttpPrincipalAccessor : IPrincipalAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpPrincipalAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor.NotNull();
        }

        public ClaimsPrincipal Principal => _httpContextAccessor.HttpContext?.User;
    }
}
