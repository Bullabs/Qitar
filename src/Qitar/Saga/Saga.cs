using System;
using System.Collections.Generic;
using Qitar.Commands;
using System.Text;
using System.Threading.Tasks;
using Qitar.Utils;

namespace Qitar.Saga
{
    public class Saga: ISaga
    {
        private readonly HashSet<ICommand> _commands = new();

        public Guid Id => throw new NotImplementedException();

        public ValueTask<bool> Publish<TCommand>(TCommand command) where TCommand : ICommand
        {
            command.NotNull();

            var results = _commands.Add(command);

            return new ValueTask<bool>(results);
        }
    }
}
