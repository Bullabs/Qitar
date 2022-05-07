using Qitar.Commands;
using Qitar.Objects.Results;
using Qitar.Queries;
using Qitar.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandCoordinator _commandCoordinator;

        public Dispatcher(IQueryProcessor queryProcessor, ICommandCoordinator commandCoordinator)
        {
            _queryProcessor = queryProcessor.NotNull();
            _commandCoordinator = commandCoordinator.NotNull();
        }

        public async ValueTask<TResult> GetResult<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult> where TResult : IResult
        {
            return await _queryProcessor.Process<TQuery, TResult>(query, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TResult> GetResult<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) where TResult : IResult
        {
            return await _queryProcessor.Process<IQuery<TResult>,TResult>(query, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<ICommandResult> Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            return await _commandCoordinator.Send(command, cancellationToken).ConfigureAwait(false);
        }
    }
}
