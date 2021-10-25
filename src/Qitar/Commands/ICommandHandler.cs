using Qitar.Messages;

namespace Qitar.Commands
{
    public interface ICommandHandler<in TCommand, TResponse> : IMessageHandler<TCommand, TResponse> where TCommand : ICommand where TResponse : ICommandResult
    {
    }

    public interface ICommandHandler<in TCommand> : IMessageHandler<TCommand> where TCommand : ICommand
    {
    }
}
