using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public class JobRunner : IJobRunner
    {
        public async ValueTask Run(IJob job, CancellationToken cancellationToken = default)
        {
            await job.Execute(cancellationToken).ConfigureAwait(false);
        }
    }
}
