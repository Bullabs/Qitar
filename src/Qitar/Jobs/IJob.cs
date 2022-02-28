using System.Threading;
using System.Threading.Tasks;
using Qitar.Dependencies;

namespace Qitar.Jobs
{
    public interface IJob
    {
        ValueTask Execute(IResolver resolver, CancellationToken cancellationToken = default);
    }
}
