using Qitar.Events;
using Qitar.Objects.Responses;
using Qitar.Validation;
using System.Collections.Generic;

namespace Qitar.Commands
{
    public class CommandResponse: IResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public IEnumerable<IEvent> Events { get; set; } 
        public ValidationResponse ValidationResults { get; set; }

        public CommandResponse(bool isSuccessful, string message, IEvent @event, ValidationResponse validationResults) : this(isSuccessful, message, validationResults)
        {
            Events = new List<IEvent>()
            {
                @event
            };
        }

        public CommandResponse(bool isSuccessful, string message, IEnumerable<IEvent> events, ValidationResponse validationResults) : this(isSuccessful, message, validationResults)
        {
            Events = events;
        }

        public CommandResponse(bool isSuccessful, string message, ValidationResponse validationResults)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ValidationResults = validationResults;
        }
    }
}
