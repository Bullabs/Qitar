using System;

namespace Qitar.Utils.Timing
{
    public interface IDateTimeRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public TimeSpan Duration { get; }
    }
}
