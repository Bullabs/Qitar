using Hangfire;
using Qitar.Jobs;
using Qitar.Objects.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Task.Hangfire
{
    public class HangfireProvider : IJobProvider
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;


        public HangfireProvider(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
            _recurringJobManager = recurringJobManager ?? throw new ArgumentNullException(nameof(recurringJobManager));
        }

        public ValueTask AddRecurringJob(IJob job, string cronExpression, CancellationToken cancellationToken = default)
        {
            _recurringJobManager.AddOrUpdate<HangfireJobWrapper>(nameof(job),j => j.Excute(job, cancellationToken).ConfigureAwait(false), cronExpression);

            return default;
        }

        public ValueTask DeleteJob(IJobId jobId, CancellationToken cancellationToken = default)
        {
            _backgroundJobClient.Delete(jobId.Id.ToString()) ;

            return default;
        }

        public ValueTask DeleteRecurringJob(IJob job, CancellationToken cancellationToken = default)
        {
            _recurringJobManager.RemoveIfExists(nameof(job));

            return default;
        }

        public ValueTask<IJobId> ScheduleJob(IJob job, TimeSpan delay, CancellationToken cancellationToken = default)
        {
            var id = _backgroundJobClient.Schedule<HangfireJobWrapper>(j => j.Excute(job, cancellationToken).ConfigureAwait(false), delay);

            return default;
        }

        public ValueTask UpdateRecurringJob(IJob job, string cronExpression, CancellationToken cancellationToken = default)
        {
            return AddRecurringJob(job, cronExpression, cancellationToken);
        }
    }
}
