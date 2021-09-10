namespace Qitar.Utils.Timing
{
    public interface IDateTimeRangeService
    {
        DateTimeRange Today { get; }
        DateTimeRange Tomorrow { get; }
        DateTimeRange LastMonth { get; }
        DateTimeRange ThisMonth { get; }
        DateTimeRange NextMonth { get; }
        DateTimeRange LastYear { get; }
        DateTimeRange ThisYear { get; }
        DateTimeRange NextYear { get; }
        DateTimeRange Last30Days { get; }
        DateTimeRange Next30Days { get; }
        DateTimeRange Last30DaysExceptToday { get; }
        DateTimeRange Last7Days { get; }
        DateTimeRange Next7Days { get; }
        DateTimeRange Last7DaysExceptToday { get; }
    }
}
