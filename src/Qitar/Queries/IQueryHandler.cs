using Qitar.Objects.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult> where TResult : IResult
    {
        ValueTask<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}
