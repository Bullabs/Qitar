using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Qitar.Bus.Kafka.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseHangfireTaks(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure<KafkaOptions>(p => configuration.GetSection("Qitar:Bus:Kafka"));
            services.AddSingleton<IBusProvider, KafkaBusProvider>();
            return services;
        }
    }
}
