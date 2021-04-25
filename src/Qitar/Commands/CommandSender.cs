using Qitar.Dependencies;
using Qitar.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandSender : ICommandSender
    {
        private readonly IResolveHandler _resolveHandler;
        private readonly IValidation _validation;

        public CommandSender(IResolveHandler resolveHandler, IValidation validation)
        {
            _resolveHandler = resolveHandler ?? throw new ArgumentNullException(nameof(resolveHandler));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }

        public async  ValueTask Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (command is IValidatable)
            {
                await _validation.Validate(command);
            }

            var handler = _resolveHandler.ResolveHandler<ICommandHandler<TCommand>>();
            await handler.Handle(command).ConfigureAwait(false);
        }
    }
}
