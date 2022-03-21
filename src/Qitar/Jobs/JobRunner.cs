using Qitar.Dependencies;
using Qitar.Logging;
using Qitar.Metrics;
using Qitar.Utils;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public class JobRunner : IJobRunner
    {
        private readonly IResolver _resolver;
        private readonly ILogger _logger;
        private readonly IMetrics _metrics;


        public JobRunner(IResolver resolver, ILogger logger, IMetrics metrics)
        {
            _resolver = resolver.NotNull();
            _logger = logger.NotNull();
            _metrics = metrics.NotNull();
        }

        public async ValueTask Run(IJob job, CancellationToken cancellationToken = default)
        {
            _logger.Debug($"Executing task {nameof(job)}");

            var jobDuration =  await PreformanceCounter(()=>job.Execute(_resolver, cancellationToken)).ConfigureAwait(false);

            await _metrics.Timer(nameof(job), jobDuration, cancellationToken).ConfigureAwait(true);
        }

        private async ValueTask<TimeSpan> PreformanceCounter(Func<ValueTask> excuter)
        {
            var stopwatch = Stopwatch.StartNew();

            await excuter.Invoke().ConfigureAwait(false);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
