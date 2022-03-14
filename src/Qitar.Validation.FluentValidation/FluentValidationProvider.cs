using FluentValidation;
using Qitar.Commands;
using Qitar.Dependencies;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Validation.FluentValidation
{
    public class FluentValidationProvider : IValidationProvider
    {
        private readonly IResolveHandler _resolveHandler;

        public FluentValidationProvider(IResolveHandler resolveHandler)
        {
            _resolveHandler = resolveHandler ?? throw new ArgumentNullException(nameof(resolveHandler));
        }

        public async  ValueTask<IValidationResult> Validate<TCommand>(TCommand command, CancellationToken canclationToken = default) where TCommand : ICommand
        {
            var validator = _resolveHandler.ResolveHandler<IValidator<TCommand>>();

            if(validator is null)
            {
                throw new ValidationException($"{nameof(command)} Validator is not found");
            }

            var validationResult = await validator.ValidateAsync(command, canclationToken).ConfigureAwait(false);

            var errors = string.Concat(validationResult.Errors.Select(s => $"{s.ErrorCode}-{s.ErrorMessage};"));
            return new ValidationResult(errors);
        }
    }
}
