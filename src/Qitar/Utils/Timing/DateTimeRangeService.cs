using System;

namespace Qitar.Utils.Timing
{
    public class DateTimeRangeService : IDateTimeRangeService
    {
        private readonly IClock _clock;

        public DateTimeRangeService(IClock clock)
        {
            _clock = clock.NotNull();
        }

        public DateTimeRange Today
        {
            get
            {
                return new DateTimeRange(_clock.Now.Date,_clock.Now.Date.AddDays(1).AddTicks(-1));
            }
        }

        public DateTimeRange Tomorrow
        {
            get
            {
                return new DateTimeRange(_clock.Now.Date.AddDays(1), _clock.Now.Date.AddDays(2).AddTicks(-1));
            }
        }

        public DateTimeRange LastMonth
        {
            get
            {
                var start = new DateTime(_clock.Now.Year, _clock.Now.Month, 1).AddMonths(-1);
                var end = start.AddMonths(1).AddDays(-1);

                return new DateTimeRange(start, end);
            }
        }

        public DateTimeRange ThisMonth
        {
            get
            {
                var start= new DateTime(_clock.Now.Year, _clock.Now.Month, 1);
                var end = start.AddMonths(1).AddDays(-1);

                return new DateTimeRange(start, end);
            }
        }

        public DateTimeRange NextMonth
        {
            get
            {
                var start = new DateTime(_clock.Now.Year, _clock.Now.Month, 1).AddMonths(1);
                var end = start.AddMonths(1).AddDays(-1);

                return new DateTimeRange(start, end);
            }
        }

        public DateTimeRange LastYear
        {
            get
            {
                var start = new DateTime(_clock.Now.Year,1, 1).AddYears(-1);
                var end = start.AddYears(1).AddDays(-1);

                return new DateTimeRange(start, end);
            }
        }

        public DateTimeRange ThisYear
        {
            get
            {
                var start = new DateTime(_clock.Now.Year, 1, 1);
                var end = start.AddYears(1).AddDays(-1);

                return new DateTimeRange(start, end);
            }
        }

        public DateTimeRange NextYear
        {
            get
            {
                var start = new DateTime(_clock.Now.Year, 1, 1).AddYears(1);
                var end = start.AddYears(1).AddDays(-1);

                return new DateTimeRange(start, end);
            }
        }

        public DateTimeRange Last30Days
        {
            get
            {
                return new DateTimeRange(_clock.Now.AddDays(-30), _clock.Now);
            }
        }

        public DateTimeRange Next30Days
        {
            get
            {
                return new DateTimeRange(_clock.Now, _clock.Now.AddDays(30));
            }
        }
        public DateTimeRange Last30DaysExceptToday
        {
            get
            {
                return new DateTimeRange(_clock.Now.AddDays(-30), _clock.Now.Date.AddTicks(-1));
            }
        }

        public DateTimeRange Last7Days
        {
            get
            {
                return new DateTimeRange(_clock.Now.AddDays(-7), _clock.Now);
            }
        }

        public DateTimeRange Next7Days
        {
            get
            {
                return new DateTimeRange(_clock.Now, _clock.Now.AddDays(0));
            }
        }

        public DateTimeRange Last7DaysExceptToday
        {
            get
            {
                return new DateTimeRange(_clock.Now.AddDays(-7), _clock.Now.Date.AddTicks(-1));
            }
        }
    }
}
