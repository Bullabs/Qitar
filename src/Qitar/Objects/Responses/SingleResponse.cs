namespace Qitar.Objects.Responses
{
    public class SingleResponse<T> : ISingleResponse<T>
    {
        public T Item { get; set; }

        public bool IsSuccess { get; set; }
    }
}
