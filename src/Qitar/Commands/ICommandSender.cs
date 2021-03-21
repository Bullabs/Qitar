using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public interface ICommandSender
    {
        ValueTask Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}
