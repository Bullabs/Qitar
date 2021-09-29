using Qitar.Permissions;
using Qitar.Utils;
using Qitar.Validation;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandValidator : ICommandValidator
    {
        private readonly IValidator _validation;
        private readonly IPermissionValidator _permissionValidator;

        public CommandValidator(IValidator validation, IPermissionValidator permissionValidator)
        {
            _validation = validation.NotNull();
            _permissionValidator = permissionValidator.NotNull();
        }

        public async ValueTask Validate<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            await _permissionValidator.Validate(command, cancellationToken).ConfigureAwait(false);

            if (command is IValidatable)
            {
                await _validation.Validate(command, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
