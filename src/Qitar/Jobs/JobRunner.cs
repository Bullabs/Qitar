using Qitar.Dependencies;
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
        private readonly IMetrics _metrics;
        private readonly IResolver _resolver;

        public JobRunner(IResolver resolver, IMetrics metrics)
        {
            _resolver = resolver.NotNull();
            _metrics = metrics.NotNull();
        }

        public async ValueTask Run(IJob job, CancellationToken cancellationToken = default)
        {
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
