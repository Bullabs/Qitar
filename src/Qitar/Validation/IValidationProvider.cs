using Qitar.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Validation
{
    public interface IValidationProvider
    {
        ValueTask<IValidationResult> Validate<TCommand>(TCommand command, CancellationToken canclationToken = default) where TCommand : ICommand;
    }
}