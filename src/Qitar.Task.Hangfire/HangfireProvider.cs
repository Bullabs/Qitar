using Hangfire;
using Qitar.Jobs;
using Qitar.Logging;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Task.Hangfire
{
    public class HangfireProvider : IJobProvider
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly ILogger _logger;

        public HangfireProvider(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, ILogger logger)
        {
            _backgroundJobClient = backgroundJobClient.NotNull();
            _recurringJobManager = recurringJobManager.NotNull();
            _logger = logger.NotNull();
        }

        public ValueTask AddRecurring(IJob job, string cronExpression, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Adding recurring job {nameof(job)}");

            _recurringJobManager.AddOrUpdate<HangfireJobWrapper>(nameof(job),j => j.Excute(job, cancellationToken).ConfigureAwait(false), cronExpression);

            return default;
        }

        public ValueTask Delete(IJobId jobId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Deleting job {jobId}");

            _backgroundJobClient.Delete(jobId.Id.ToString());

            return default;
        }

        public ValueTask DeleteRecurring(IJob job, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Deleting recurring job {nameof(job)}");

            _recurringJobManager.RemoveIfExists(nameof(job));

            return default;
        }

        public ValueTask<IJobId> Schedule(IJob job, DateTimeOffset runAt, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Scheduling job {nameof(job)}");

            var id = _backgroundJobClient.Schedule<HangfireJobWrapper>(j => j.Excute(job, cancellationToken).ConfigureAwait(false), runAt);

            return new ValueTask<IJobId>(new HangfireJobId(id));
        }

        public ValueTask<IJobId> Schedule(IJob job, TimeSpan delay, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Scheduling job {nameof(job)}");

            var id = _backgroundJobClient.Schedule<HangfireJobWrapper>(j => j.Excute(job, cancellationToken).ConfigureAwait(false), delay);

            return new ValueTask<IJobId>(new HangfireJobId(id));
        }

        public ValueTask<IJobId> Schedule(IJob job, CancellationToken cancellationToken = default)
        {
            return Schedule(job,TimeSpan.Zero,cancellationToken);
        }

        public ValueTask UpdateRecurring(IJob job, string cronExpression, CancellationToken cancellationToken = default)
        {
            _logger.Information($"Updating recurring job {nameof(job)}");

            return AddRecurring(job, cronExpression, cancellationToken);
        }
    }
}