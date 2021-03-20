using Qitar.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Dispatcher
{
    public interface IDispatcher
    {
        ValueTask<TResult> GetResult<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
