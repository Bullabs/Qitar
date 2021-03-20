using System;

namespace Qitar.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
