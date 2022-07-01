using System.Security.Claims;
using System.Threading;

namespace Qitar.Security
{
    public class ThreadPrincipalAccessor : IPrincipalAccessor
    {
        ClaimsPrincipal IPrincipalAccessor.Principal => Thread.CurrentPrincipal as ClaimsPrincipal;
    }
}

