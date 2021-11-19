namespace Qitar.Objects.Results
{
    public interface ISingleResult<T> : IResult
    {
        T Value { get; }
    }
}