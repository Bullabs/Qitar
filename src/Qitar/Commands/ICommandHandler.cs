using Qitar.Objects.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public interface ICommandHandler<in TCommand,TResponse> where TCommand : ICommand where TResponse: IResponse
    { 
        ValueTask Handle(TCommand request, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, CommandResponse> where TCommand : ICommand
    {
    }
}
