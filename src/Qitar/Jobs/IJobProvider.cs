using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public interface IJobProvider
    {
        ValueTask<IJobId> Schedule(IJob job, TimeSpan delay,CancellationToken cancellationToken = default);
        ValueTask<IJobId> Schedule(IJob job, DateTimeOffset runAt, CancellationToken cancellationToken = default);
        ValueTask<IJobId> Schedule(IJob job, CancellationToken cancellationToken = default);
        ValueTask Delete(IJobId jobId , CancellationToken cancellationToken = default);
        ValueTask AddRecurring(IJob job, string cronExpression, CancellationToken cancellationToken = default);
        ValueTask UpdateRecurring(IJob job, string cronExpression, CancellationToken cancellationToken = default);
        ValueTask DeleteRecurring(IJob job, CancellationToken cancellationToken = default);
    }
}
