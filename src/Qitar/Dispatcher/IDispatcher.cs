using Qitar.Commands;
using Qitar.Objects.Results;
using Qitar.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Dispatcher
{
    public interface IDispatcher
    {
        ValueTask<ICommandResult> Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
        ValueTask<TResult> GetResult<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) where TResult : IResult;
    }
}
