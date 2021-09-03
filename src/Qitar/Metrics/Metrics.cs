using Qitar.Messages;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Metrics
{
    public class Metrics : IMetrics
    {
        private readonly IMetricsProvider _metricsProvider;

        public Metrics(IMetricsProvider metricsProvider)
        {
            _metricsProvider = metricsProvider ?? throw new ArgumentNullException(nameof(metricsProvider));
        }

        public async ValueTask Counter(string name, int value = 1, CancellationToken cancellationToken = default)
        {
            await _metricsProvider.Counter(name, value, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask Counter(IMessage message, CancellationToken cancellationToken = default)
        {
            await Counter(nameof(message), 1, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask Gauge(string name, double value, CancellationToken cancellationToken = default)
        {
            await _metricsProvider.Gauge(name, value, cancellationToken).ConfigureAwait(false);
        }

        public ValueTask GetCounterStats(string name, DateTime? utcStart = null, DateTime? utcEnd = null, int dataPoints = 20, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask Timer(string name, TimeSpan Time, CancellationToken cancellationToken = default)
        {
            var totalMilliseconds = Convert.ToInt32(Time.TotalMilliseconds);
            await _metricsProvider.Timer(name, totalMilliseconds, cancellationToken).ConfigureAwait(false);
        }
    }
}
