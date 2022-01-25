using Qitar.Messages;
using Qitar.Objects.Results;

namespace Qitar.Commands
{
    public interface ICommandHandler<in TCommand> : IMessageHandler<TCommand, ICommandResult> where TCommand : ICommand
    {
    }
    public interface ICommandHandler<in TCommand, TCommandResult> : IMessageHandler<TCommand, TCommandResult> where TCommand : ICommand where TCommandResult : IResult
    {
    }
}
