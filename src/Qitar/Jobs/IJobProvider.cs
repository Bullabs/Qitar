using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public interface IJobProvider
    {
        ValueTask<IJobId> ScheduleJob(IJob job, TimeSpan delay,CancellationToken cancellationToken = default);
        ValueTask DeleteJob(IJobId jobId , CancellationToken cancellationToken = default);
        ValueTask AddRecurringJob(IJob job, string cronExpression, CancellationToken cancellationToken = default);
        ValueTask UpdateRecurringJob(IJob job, string cronExpression, CancellationToken cancellationToken = default);
        ValueTask DeleteRecurringJob(IJob job, CancellationToken cancellationToken = default);
    }
}
