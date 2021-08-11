using Qitar.Messages;
using Qitar.Objects.Responses;

namespace Qitar.Commands
{
    public interface ICommandHandler<in TCommand,TResponse> : IMessageHandler<TCommand, TResponse> where TCommand : ICommand where TResponse: IResponse
    {
    }

    public interface ICommandHandler<in TCommand> : IMessageHandler<TCommand> where TCommand : ICommand
    {
    }
}
