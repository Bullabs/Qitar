using Qitar.Commands;
using System.Threading.Tasks;

namespace Qitar.Validation
{
    public interface IValidation
    {
        ValueTask Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}