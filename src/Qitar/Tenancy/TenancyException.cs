using System;
using System.Runtime.Serialization;

namespace Qitar.Tenancy
{
    [Serializable]
    public class TenancyException : Exception
    {
        public TenancyException(string errorMessage) : base(errorMessage)
        {
        }

        public TenancyException() : base()
        {
        }

        public TenancyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TenancyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
