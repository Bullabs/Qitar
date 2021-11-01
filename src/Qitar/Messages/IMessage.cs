using System;

namespace Qitar.Messages
{
    public interface IMessage
    {
        public Guid Id { get; }
        Guid CorrelationId { get; }
    }
}
