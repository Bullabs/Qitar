using System;

namespace Qitar.Utils.Timing
{
    public interface IClockProvider
    {
        DateTime Now { get; }
        bool SupportsMultipleTimezone { get; }
        DateTimeKind DateTimeKind {get;}
    }
}
