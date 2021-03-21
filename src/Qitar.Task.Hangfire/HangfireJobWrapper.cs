using Qitar.Jobs;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Task.Hangfire
{
    class HangfireJobWrapper
    {
        private readonly IJobRunner _jobRunner;

        public HangfireJobWrapper(IJobRunner jobRunner)
        {
            _jobRunner = jobRunner;
        }

        public async ValueTask Excute(IJob job, CancellationToken cancellationToken)
        {
            await _jobRunner.Run(job, cancellationToken).ConfigureAwait(false);
        }
    }
}
