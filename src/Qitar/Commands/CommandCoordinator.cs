using Qitar.Dependencies;
using Qitar.Logging;
using Qitar.Metrics;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandCoordinator : ICommandCoordinator
    {
        private readonly IResolveHandler _resolveHandler;
        private readonly ICommandValidator _validation;
        private readonly IMetrics _metrics;
        readonly ILogger _logger;

        public CommandCoordinator(IResolveHandler resolveHandler, ICommandValidator validation, IMetrics metrics, ILogger logger)
        {
            _resolveHandler = resolveHandler.NotNull();
            _validation = validation.NotNull();
            _metrics = metrics.NotNull();
            _logger = logger.NotNull();
        }

        public async  ValueTask Process<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            _logger.Information("Handle command");

            command.NotNull();
            
            await _metrics.Counter(command, cancellationToken).ConfigureAwait(false);

            await _validation.Validate(command).ConfigureAwait(false);

            var handler = _resolveHandler.ResolveHandler<ICommandHandler<TCommand>>();

            await handler.Handle(command,cancellationToken).ConfigureAwait(false);
        }
    }
}
