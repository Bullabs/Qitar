namespace Qitar.Objects.Responses
{
    public class SingleResult<T> : ISingleResult<T>
    {
        public T Item { get; set; }
    }
}