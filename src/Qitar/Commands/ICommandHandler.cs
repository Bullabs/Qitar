using Qitar.Messages;

namespace Qitar.Commands
{
    public interface ICommandHandler<in TCommand> : IMessageHandler<TCommand, ICommandResult> where TCommand : ICommand
    {
    }
}
