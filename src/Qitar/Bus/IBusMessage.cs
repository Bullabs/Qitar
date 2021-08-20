using System;

namespace Qitar.Bus
{
    public interface IBusMessage
    {
        public DateTime? ScheduledEnqueueTimeUtc { get; set; }
    }
}
