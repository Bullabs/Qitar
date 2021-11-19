using System.Collections.Generic;

namespace Qitar.Objects.Results
{
    public interface IListResult<T> : IResult
    {
        IList<T> Values { get; }
    }
}
