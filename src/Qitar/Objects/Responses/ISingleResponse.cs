namespace Qitar.Objects.Responses
{
    public interface ISingleResponse<out T> : IResponse
    {
        T Item { get; }
    }
}
