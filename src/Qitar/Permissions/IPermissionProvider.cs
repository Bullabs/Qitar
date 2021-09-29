using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Permissions
{
    public interface IPermissionProvider
    {
        ValueTask<bool> HasPermissions(Guid UserId, string[] permissions, CancellationToken canclationToken = default);
         ValueTask<IEnumerable<string>> GetUserPermissions(Guid UserId, CancellationToken cancellationToken);
    }
}
