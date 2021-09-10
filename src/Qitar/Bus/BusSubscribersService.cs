using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public class BusSubscribersService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
