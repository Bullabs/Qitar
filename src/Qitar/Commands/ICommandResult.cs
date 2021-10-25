using Qitar.Events;
using Qitar.Objects.Responses;
using Qitar.Validation;
using System.Collections.Generic;

namespace Qitar.Commands
{
    public interface ICommandResult: IResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public IEnumerable<IEvent> Events { get; set; }
        public IValidationResult ValidationResults { get; set; }
    }
}
