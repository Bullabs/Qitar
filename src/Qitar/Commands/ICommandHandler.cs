using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        ValueTask Handle(TCommand request, CancellationToken cancellationToken = default);
    }
}
