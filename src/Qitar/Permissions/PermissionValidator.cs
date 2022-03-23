using Qitar.Commands;
using Qitar.Logging;
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
        private readonly ILogger _logger;

        public PermissionValidator(IPermissionProvider permissionProvider, ILogger logger)
        {
            _permissionProvider = permissionProvider.NotNull();
            _logger = logger.NotNull();
        }

        public async ValueTask Validate<TCommand>(TCommand command, CancellationToken canclationToken = default) where TCommand : ICommand
        {
            var type = command.GetType();

            _logger.Information($"Validating {type.Name} Permissions");

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