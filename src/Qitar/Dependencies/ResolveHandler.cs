using System;
using System.Collections.Generic;
using System.Text;

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

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(THandler));
            }

            return handler;
        }
    }
}
