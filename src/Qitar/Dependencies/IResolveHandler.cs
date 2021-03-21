namespace Qitar.Dependencies
{
    public interface IResolveHandler
    {
        THandler ResolveHandler<THandler>();
    }
}
