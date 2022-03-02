using Qitar.Utils;

namespace Qitar.Dependencies
{
    public class ResolveHandler: IResolveHandler
    {
        private readonly IResolver _resolver;

        public ResolveHandler(IResolver resolver)
        {
            _resolver = resolver.NotNull();
        }

        THandler IResolveHandler.ResolveHandler<THandler>()
        {
            var handler = _resolver.Resolve<THandler>();

            handler.NotNull();

            return handler;
        }
    }
}