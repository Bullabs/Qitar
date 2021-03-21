using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public interface IJobRunner
    {
        ValueTask Run(IJob job, CancellationToken cancellationToken);
    }
}
