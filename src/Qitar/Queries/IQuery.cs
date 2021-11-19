using Qitar.Objects.Results;

namespace Qitar.Queries
{
    public interface IQuery<out TResult> 
    {
    }
    public interface IQuery: IQuery<IResult>
    {
    }
}
