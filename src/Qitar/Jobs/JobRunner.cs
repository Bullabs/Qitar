using Qitar.Metrics;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public class JobRunner : IJobRunner
    {
        private readonly IMetrics _metrics;
        public JobRunner(IMetrics metrics)
        {
            _metrics = metrics ?? throw new ArgumentNullException(nameof(metrics));
        }

        public async ValueTask Run(IJob job, CancellationToken cancellationToken = default)
        {
            var jobDuration =  await PreformanceCounter(()=>job.Execute(cancellationToken)).ConfigureAwait(false);

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
