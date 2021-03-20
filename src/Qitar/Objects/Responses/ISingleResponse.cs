namespace Qitar.Objects.Responses
{
    public interface ISingleResponse<T> : IResponse
    {
        T Item { get; }
    }
}
