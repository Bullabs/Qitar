using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Queries
{
    public interface IQueryProcessor
    {
        ValueTask<TResult> Process<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResult>;
    }
}
