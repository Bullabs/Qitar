using Qitar.Messages;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Metrics
{
    public interface IMetrics
    {
        ValueTask Counter(string name, int value = 1, CancellationToken cancellationToken = default);
        ValueTask Counter(IMessage message, CancellationToken cancellationToken = default);
        ValueTask Gauge(string name, double value, CancellationToken cancellationToken = default);
        ValueTask Timer(string name, TimeSpan Time, CancellationToken cancellationToken = default);
        ValueTask GetCounterStats(string name, DateTime? utcStart = null, DateTime? utcEnd = null, int dataPoints = 20, CancellationToken cancellationToken = default);
    }
}
