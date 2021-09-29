using Qitar.Commands;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Validation
{
    public class Validation : IValidator
    {
        private readonly IValidationProvider _validationProvider;

        public Validation(IValidationProvider validationProvider)
        {
            _validationProvider = validationProvider ?? throw new ArgumentNullException(nameof(validationProvider));
        }

        public async ValueTask Validate<TCommand>(TCommand command, CancellationToken canclationToken = default) where TCommand : ICommand
        {
            command.NotNull();

            var response = await _validationProvider.Validate(command, canclationToken).ConfigureAwait(false);

            if (!response.IsValid)
            {
                throw new ValidationException(response.Error);
            }
        }
    }
}
