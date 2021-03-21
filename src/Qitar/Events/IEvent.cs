using Qitar.Messages;
using System;

namespace Qitar.Events
{
    public interface IEvent: IMessage
    {
        Guid StreamId { get; }
    }
}
