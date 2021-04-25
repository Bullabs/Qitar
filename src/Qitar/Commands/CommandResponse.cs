using Qitar.Objects.Responses;
using Qitar.Validation;

namespace Qitar.Commands
{
    public class CommandResponse: IResponse
    {
        public bool isSuccessful { get; set; }
        public string Message { get; set; }
        public ValidationResponse ValidationResults { get; set; }

        public CommandResponse(bool isSuccessful, string message, ValidationResponse validationResults)
        {
            this.isSuccessful = isSuccessful;
            Message = message;
            ValidationResults = validationResults;
        }
    }
}
