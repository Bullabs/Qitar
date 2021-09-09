using System;

namespace Qitar.Utils.Timing
{
    public class Clock : IClock
    {
        private readonly IClockProvider _clockProvider;

        public Clock(IClockProvider clockProvider)
        {
            _clockProvider = clockProvider.NotNull();
        }

        public DateTime Now => _clockProvider.Now;

        public DateTime Normalize(DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, _clockProvider.DateTimeKind);
        }
    }
}
