using Qitar.Commands;
using System;
using System.Threading.Tasks;

namespace Qitar.Saga
{
    public interface ISaga
    {
        Guid Id { get; }
        ValueTask<bool> Publish<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
