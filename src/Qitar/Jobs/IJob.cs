using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Jobs
{
    public interface IJob
    {
        ValueTask Execute(CancellationToken cancellationToken = default);
    }
}
