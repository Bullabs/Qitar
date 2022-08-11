using System;
using System.Collections.Generic;

namespace Qitar.Bus
{
    internal class BusMessage : IBusMessage
    {
        public DateTime? ScheduledEnqueueTimeUtc { get; set; }
        public Dictionary<string, object> Headers { get; set; }
        public Guid Id { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
