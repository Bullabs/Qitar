using System;

namespace Qitar.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMessage) : base(errorMessage)
        {
        }

        public ValidationException() : base()
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
