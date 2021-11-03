using Qitar.Dependencies;
using Qitar.Events;
using Qitar.Logging;
using Qitar.Mapping;
using Qitar.Metrics;
using Qitar.Permissions;
using Qitar.Utils;
using Qitar.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public class CommandCoordinator : ICommandCoordinator
    {
        private readonly IResolveHandler _resolveHandler;
        private readonly IEventPublisher _eventPublisher;
        private readonly ICommandValidator _validation;
        private readonly IPermissionValidator _permissionValidator;
        private readonly IMapper _mapper;
        private readonly IMetrics _metrics;
        readonly ILogger _logger;

        public CommandCoordinator(IResolveHandler resolveHandler, IEventPublisher eventPublisher, ICommandValidator validation, IPermissionValidator permissionValidator, IMapper mapper,IMetrics metrics, ILogger logger)
        {
            _resolveHandler = resolveHandler.NotNull();
            _eventPublisher = eventPublisher.NotNull();
            _validation = validation.NotNull();
            _permissionValidator = permissionValidator.NotNull();
            _mapper = _mapper.NotNull();
            _metrics = metrics.NotNull();
            _logger = logger.NotNull();
        }

        public async  ValueTask<ICommandResult> Send<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            command.NotNull();
            _logger.Information("Handle command");

            return await Process(command, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<ICommandResult> Process<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            var commandResult = new CommandResult();

            try
            {
                await _permissionValidator.Validate(command, cancellationToken).ConfigureAwait(false);
                await _validation.Validate(command, cancellationToken).ConfigureAwait(false);

                var concreteCommand = _mapper.CreateConcreteObject(command);
                var handler = _resolveHandler.ResolveHandler<ICommandHandler<TCommand>>();
                commandResult = (CommandResult) await handler.Handle(concreteCommand).ConfigureAwait(false);

                await _eventPublisher.Publish(commandResult.Events, cancellationToken).ConfigureAwait(false);
            }
            catch(PermissionValidationException ex)
            {
                _logger.Error(ex, "Error command permission validation");
                commandResult.Exception = ex;
            }
            catch (ValidationException ex)
            {
                _logger.Error(ex, "Error command validation");
                commandResult.Exception = ex;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Command was not successful");
                commandResult.Exception = ex;
            }

            return commandResult;
        }
    }
}