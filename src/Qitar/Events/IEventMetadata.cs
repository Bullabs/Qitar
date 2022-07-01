using Qitar.Messages;
using System;

namespace Qitar.Events
{
    public interface IEventMetadata: IMessageMetadata
    {
        Guid EventId { get; }
        string EventName { get; }
        int EventVersion { get; }
        DateTimeOffset TimeStamp { get; }
        string AggregateId { get;}
    }
}
