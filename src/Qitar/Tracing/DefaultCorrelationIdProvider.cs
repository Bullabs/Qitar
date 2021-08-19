using System;

namespace Qitar.Tracing
{
    public class DefaultCorrelationIdProvider : ICorrelationIdProvider
    {
        public string Get()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
