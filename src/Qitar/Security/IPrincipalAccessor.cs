using System.Security.Claims;

namespace Qitar.Security
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}
