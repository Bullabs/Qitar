using Qitar.Dependencies;
using Qitar.Metrics;
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
        private readonly IMetrics _metrics;

        public CommandSender(IResolveHandler resolveHandler, ICommandValidator validation, IMetrics metrics)
        {
            _resolveHandler = resolveHandler ?? throw new ArgumentNullException(nameof(resolveHandler));
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
            _metrics = metrics ?? throw new ArgumentNullException(nameof(metrics));
        }

        public async  ValueTask Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            command.NotNull();
            
            await _metrics.Counter(command, cancellationToken).ConfigureAwait(false);

            await _validation.Validate(command).ConfigureAwait(false);

            var handler = _resolveHandler.ResolveHandler<ICommandHandler<TCommand>>();
            await handler.Handle(command).ConfigureAwait(false);
        }
    }
}
