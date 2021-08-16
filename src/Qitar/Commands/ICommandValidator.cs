using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public interface ICommandValidator
    {
        ValueTask Validate<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}
