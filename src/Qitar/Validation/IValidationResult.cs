using Qitar.Objects.Responses;
using System.Collections.Generic;

namespace Qitar.Validation
{
    public interface IValidationResult: IResult
    {
        string Error { get; set;}
        bool IsValid { get; set; }
    }
}
