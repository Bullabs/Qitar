using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        ValueTask<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
