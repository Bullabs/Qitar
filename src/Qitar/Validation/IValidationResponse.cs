using Qitar.Objects.Responses;
using System.Collections.Generic;

namespace Qitar.Validation
{
    public interface IValidationResponse: IResponse
    {
        IEnumerable<ValidationError> Errors { get; set;}
        bool IsValid { get; set; }
    }
}
