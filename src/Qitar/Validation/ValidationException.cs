using System;
using System.Runtime.Serialization;

namespace Qitar.Validation
{
    [Serializable]
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
        
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
