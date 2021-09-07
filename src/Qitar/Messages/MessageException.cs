using System;
using System.Runtime.Serialization;

namespace Qitar.Messages
{
    [Serializable]
    public class MessageException: Exception
    {
        public MessageException() : base()
        {
        }

        public MessageException(string message) : base(message)
        {
        }

        public MessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MessageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
