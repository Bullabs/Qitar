using Qitar.Commands;
using Qitar.Utils;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Permissions
{
    public class PermissionValidator : IPermissionValidator
    {
        private readonly IPermissionProvider _permissionProvider;

        public PermissionValidator(IPermissionProvider permissionProvider)
        {
            _permissionProvider = permissionProvider.NotNull();
        }

        public async ValueTask Validate<TCommand>(TCommand command, CancellationToken canclationToken = default) where TCommand : ICommand
        {
            var type = command.GetType();

            var permissions = type.GetCustomAttribute<HasPermissionsAttribute>()?.PermissionCodes;
            if (permissions != null && permissions.Any())
            {
               var permissionFlag= await _permissionProvider.HasPermissions(System.Guid.Empty, permissions, canclationToken).ConfigureAwait(false);
                if (!permissionFlag)
                {
                    throw new PermissionValidationException();
                }
            }

        }
    }
}
