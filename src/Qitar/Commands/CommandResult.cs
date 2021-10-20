using Qitar.Events;
using Qitar.Validation;
using System.Collections.Generic;

namespace Qitar.Commands
{
    public class CommandResult: ICommandResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public IEnumerable<IEvent> Events { get; set; } 
        public IValidationResult ValidationResults { get; set; }

        public CommandResult(bool isSuccessful, string message, IEvent @event, ValidationResult validationResults) : this(isSuccessful, message, validationResults)
        {
            Events = new List<IEvent>()
            {
                @event
            };
        }

        public CommandResult(bool isSuccessful, string message, IEnumerable<IEvent> events, ValidationResult validationResults) : this(isSuccessful, message, validationResults)
        {
            Events = events;
        }

        public CommandResult(bool isSuccessful, string message, ValidationResult validationResults)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ValidationResults = validationResults;
        }
    }
}
