using Qitar.Objects.Results;

namespace Qitar.Queries
{
    public interface IQuery<out TResult> where TResult : IResult
    {
    }
    public interface IQuery: IQuery<IResult>
    {
    }
}
