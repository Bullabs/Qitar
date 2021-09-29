using System;
using System.Runtime.Serialization;

namespace Qitar.Permissions
{
    public class PermissionValidationException : Exception
    {
        public PermissionValidationException(string errorMessage) : base(errorMessage)
        {
        }

        public PermissionValidationException() : base()
        {
        }

        public PermissionValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PermissionValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
