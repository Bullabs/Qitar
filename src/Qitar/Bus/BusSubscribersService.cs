using Microsoft.Extensions.Hosting;
using Qitar.Logging;
using Qitar.Messages;
using Qitar.Utils;
using Qitar.Utils.System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public class BusSubscribersService : IHostedService
    {
        private readonly IEnumerable<IMessageSubscriber> _subscribers;
        private readonly ILogger _logger;
        private readonly ISystemInfo _systemInfo;

       public BusSubscribersService(IEnumerable<IMessageSubscriber> subscribers, ILogger logger, ISystemInfo systemInfo)
        {
            _subscribers = subscribers.NotNull();
            _logger = logger.NotNull();
            _systemInfo = systemInfo.NotNull();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information($"starting message subscribers on {_systemInfo.MachineName}");

            //var tasks =  _subscribers.Select(s => s.Subscribe(cancellationToken).AsTask());
            //var combinedTask = Task.WhenAll(tasks);
            //return combinedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information($"stopping message subscribers on {_systemInfo.MachineName}");

            //await Task.WhenAll(_subscribers.Select(s => s.Unsubscribe(cancellationToken).AsTask()));
        }
    }
}
