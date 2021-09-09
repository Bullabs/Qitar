using System;

namespace Qitar.Utils.Timing
{
    public class UtcClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.UtcNow;

        public bool SupportsMultipleTimezone => true;

        public DateTimeKind DateTimeKind => DateTimeKind.Utc;
    }
}

