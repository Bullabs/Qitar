using Microsoft.Extensions.Options;
using Qitar.Logging;
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
        private readonly ConnectionOptions _options;
        private readonly ILogger _logger;

        public ConnectionResolver(ICurrentTenant tenant, IConnectionFactory connectionFactory, IOptions<ConnectionOptions> options, ILogger logger)
        {
            _tenant = tenant.NotNull();
            _connectionFactory = connectionFactory.NotNull();
            _options = options.Value;
            _logger = logger.NotNull();
        }

        public async ValueTask<IDbConnection> Resolve(CancellationToken cancellationToken = default)
        {
            _logger.Information("Resolving DB connection");

            if (_tenant == null || string.IsNullOrEmpty(_tenant.ConnectionString))
            {
                return await _connectionFactory.Create(_options.ConnectionType, _options.ConnectionString, cancellationToken).ConfigureAwait(false);
            }

            return await _connectionFactory.Create(_tenant.ConnectionType, _tenant.ConnectionString, cancellationToken).ConfigureAwait(false);
        }
    }
}