using Qitar.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandValidator : ICommandValidator
    {
        private readonly IValidation _validation;

        public CommandValidator(IValidation validation)
        {
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }

        public async ValueTask Validate<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            if (command is IValidatable)
            {
                await _validation.Validate(command, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
