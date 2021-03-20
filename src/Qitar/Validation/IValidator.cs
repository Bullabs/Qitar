using Qitar.Commands;
using System.Threading.Tasks;

namespace Qitar.Validation
{
    public interface IValidator
    {
        ValueTask<IValidationResponse> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}