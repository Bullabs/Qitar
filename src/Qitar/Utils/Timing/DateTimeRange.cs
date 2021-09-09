using System;

namespace Qitar.Utils.Timing
{
    public struct DateTimeRange : IDateTimeRange, IEquatable<DateTimeRange>
    {
        public DateTimeRange(DateTime start, DateTime end): this()
        {
            Start = start.NotNull();
            End = end.NotNull();

            if (End < Start)
            {
                throw new ArgumentException("End date must be greater than or equal to start date");
            }
        }

        public DateTime Start { get;}
        public DateTime End { get;}
        public TimeSpan Duration => End - Start;

        public bool Equals(DateTimeRange other)
        {
            throw new NotImplementedException();
        }

    }
}
