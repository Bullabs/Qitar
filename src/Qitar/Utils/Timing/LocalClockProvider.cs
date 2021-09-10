using System;

namespace Qitar.Utils.Timing
{
    public class LocalClockProvider : IClockProvider
    {
        public DateTime Now => DateTime.Now;

        public bool SupportsMultipleTimezone => false;

        public DateTimeKind DateTimeKind => DateTimeKind.Local;
    }
}
