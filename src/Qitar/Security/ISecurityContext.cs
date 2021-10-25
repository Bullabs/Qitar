using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Security
{
    public interface ISecurityContext
    {
        ValueTask<bool> HasPermissions(string[] permissions, CancellationToken cancellationToken=default);
        ValueTask<IEnumerable<string>> GetUserPermissions(CancellationToken cancellationToken);
        ValueTask<bool> CheckPermissions(string[] permissions, CancellationToken cancellationToken = default);
    }
}
