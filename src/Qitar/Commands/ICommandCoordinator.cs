using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public interface ICommandCoordinator
    {
        ValueTask Process<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}
