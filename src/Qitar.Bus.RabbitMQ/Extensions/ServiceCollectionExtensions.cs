using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Bus.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseHangfireTaks(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure<RabbitMQOptions>(p => configuration.GetSection("Qitar:Bus:RabbitMQ"));
            services.AddSingleton<IBusProvider, RabbitMQBusProvider>();

            return services;
        }
    }
}
