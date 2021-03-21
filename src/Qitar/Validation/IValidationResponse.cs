using Qitar.Objects.Responses;
using System.Collections.Generic;

namespace Qitar.Validation
{
    public interface IValidationResponse: IResponse
    {
        string Error { get; set;}
        bool IsValid { get; set; }
    }
}
