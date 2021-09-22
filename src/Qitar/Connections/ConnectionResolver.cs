using Qitar.Tenancy;
using Qitar.Utils;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Connections
{
    public class ConnectionResolver : IConnectionResolver
    {
        private readonly ICurrentTenant _tenant;
        private readonly IConnectionFactory _connectionFactory;


        public ConnectionResolver(ICurrentTenant tenant, IConnectionFactory connectionFactory)
        {
            _tenant = tenant.NotNull();
            _connectionFactory = connectionFactory.NotNull();
        }

        public async ValueTask<IDbConnection> Resolve(string defaultConnectionString, CancellationToken cancellationToken = default)
        {
            var type = 0;
            var conString = defaultConnectionString.NotNull();

            if (_tenant.Id.HasValue)
            {
                type = _tenant.ConnectionType;
                conString = _tenant.ConnectionString;
            }

            return await _connectionFactory.Create(type, conString, cancellationToken).ConfigureAwait(false);

        }
    }
}
