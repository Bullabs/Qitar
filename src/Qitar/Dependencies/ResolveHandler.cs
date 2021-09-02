using Qitar.Utils;
using System;

namespace Qitar.Dependencies
{
    public class ResolveHandler: IResolveHandler
    {
        private readonly IResolver _resolver;

        public ResolveHandler(IResolver resolver)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        THandler IResolveHandler.ResolveHandler<THandler>()
        {
            var handler = _resolver.Resolve<THandler>();

            handler.NotNull();

            return handler;
        }
    }
}
