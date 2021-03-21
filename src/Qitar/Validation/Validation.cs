using Qitar.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Validation
{
    public class Validation : IValidation
    {
        private readonly IValidationProvider _validationProvider;

        public Validation(IValidationProvider validationProvider)
        {
            _validationProvider = validationProvider;
        }

        public async ValueTask Validate<TCommand>(TCommand command, CancellationToken canclationToken = default) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var response = await _validationProvider.Validate(command, canclationToken).ConfigureAwait(false);

            if (!response.IsValid)
            {
                throw new ValidationException(response.Error);
            }
        }
    }
}
