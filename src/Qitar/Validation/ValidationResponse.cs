using System.Collections.Generic;

namespace Qitar.Validation
{
    public class ValidationResponse : IValidationResponse
    {
        public IEnumerable<ValidationError> Errors { get; set; }
        public bool IsValid { get; set; }

        public bool IsSuccess => throw new System.NotImplementedException();
    }
}
