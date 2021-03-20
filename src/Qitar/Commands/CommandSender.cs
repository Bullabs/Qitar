using Qitar.Dependencies;
using Qitar.Objects.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandSender : ICommandSender
    {
        private readonly IResolveHandler _resolveHandler;
        public CommandSender(IResolveHandler resolveHandler)
        {
            _resolveHandler = resolveHandler;
        }

        public async  ValueTask Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            //_resolveHandler.ResolveHandler<ICommandHandler<>
            await new ValueTask().ConfigureAwait(false);
        }
    }
}
