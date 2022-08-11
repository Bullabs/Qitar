using Qitar.Messages;
using System;
using System.Collections.Generic;

namespace Qitar.Bus
{
    public interface IBusMessage: IMessage
    {
        public DateTime? ScheduledEnqueueTimeUtc { get; set; }
        public Dictionary<string, Object> Headers { get; set; }
    }
}
