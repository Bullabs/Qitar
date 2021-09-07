using Qitar.Utils;
using Qitar.Utils.Timer;
using System;
using System.Diagnostics;

namespace Qitar.Metrics
{
    public class MetricsTimer : ITimer
    {
        private readonly IMetrics _metrics;

        public MetricsTimer(IMetrics metrics)
        {
            _metrics = metrics.NotNull();
        }

        public T Time<T>(Func<T> action)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                return action();
            }
            finally
            {
                stopwatch.Stop();
                _metrics.Timer("", stopwatch.Elapsed);
            }
        }

        public void Time(Action action)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                 action();
            }
            finally
            {
                stopwatch.Stop();
                _metrics.Timer("", stopwatch.Elapsed);
            }
        }
    }
}
