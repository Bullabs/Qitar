using Qitar.Objects.Results;

namespace Qitar.Queries
{
    public interface IListQuery<TResult> : IQuery<IListResult<TResult>>
    {
    }
}
