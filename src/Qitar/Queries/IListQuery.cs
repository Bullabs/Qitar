using System.Collections.Generic;

namespace Qitar.Queries
{
    public interface IListQuery<TResult> : IQuery<IReadOnlyList<TResult>>
    {
    }
}
