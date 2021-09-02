using Qitar.Dependencies;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandSender : ICommandSender
    {
        private readonly IResolveHandler _resolveHandler;
        private readonly ICommandValidator _validation;

        public CommandSender(IResolveHandler resolveHandler, ICommandValidator validation)
        {
            _resolveHandler = resolveHandler ?? throw new ArgumentNullException(nameof(resolveHandler));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
        }

        public async  ValueTask Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            command.NotNull();

            await _validation.Validate(command).ConfigureAwait(false);

            var handler = _resolveHandler.ResolveHandler<ICommandHandler<TCommand>>();
            await handler.Handle(command).ConfigureAwait(false);
        }
    }
}
