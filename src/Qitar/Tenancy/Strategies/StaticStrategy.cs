using Qitar.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Strategies
{
    public class StaticStrategy : ITenantStrategy
    {
        private readonly string _identifier;
        public StaticStrategy(string identifier)
        {
            _identifier = identifier.NotNull();
        }

        public ValueTask<string> GetIdentifier(object context, CancellationToken cancellationToken = default)
        {
            return new ValueTask<string>(_identifier);
        }
    }
}
