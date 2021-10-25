namespace Qitar.Objects.Responses
{
    public interface ISingleResult<out T> : IResult
    {
        T Item { get; }
    }
}
