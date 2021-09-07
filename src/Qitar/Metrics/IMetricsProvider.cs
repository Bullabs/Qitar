using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Metrics
{
    public interface IMetricsProvider
    {
        ValueTask Counter(string name, int value, CancellationToken cancellationToken = default);
        ValueTask Gauge(string name, double value, CancellationToken cancellationToken = default);
        ValueTask Timer(string name, int milliseconds, CancellationToken cancellationToken = default);
    }
}
