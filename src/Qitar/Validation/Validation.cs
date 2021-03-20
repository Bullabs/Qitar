using Qitar.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qitar.Validation
{
    public class Validation : IValidation
    {
        private readonly IValidator _validator;

        public Validation(IValidator validator)
        {
            _validator = validator;
        }

        public async ValueTask Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));

            }

            var response = await _validator.Validate(command);

            if (!response.IsValid)
            {
                throw new ValidationException(BuildErrorMessage(response.Errors));
            }
        }

        private static string BuildErrorMessage(IEnumerable<ValidationError> errors)
        {
            var errorsText = errors.Select(x => $"\r\n - {x.ErrorMessage}").ToArray();
            return $"Validation failed: {string.Join("", errorsText)}";
        }
    }
}
