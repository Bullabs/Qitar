using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Qitar.Bus.Kafka.Factories;
using Qitar.Utils.System;
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

            services.AddSingleton(ctx =>
            {
                var config = ctx.GetRequiredService<IOptions<KafkaOptions>>().Value;
                var systemInfo = ctx.GetRequiredService<ISystemInfo>();
                return new ProducerConfig() 
                { 
                    BootstrapServers = config.BootstrapServers, 
                    ClientId = systemInfo.MachineName,
                };
            });

            services.AddSingleton(ctx =>
            {
                var config = ctx.GetRequiredService<ProducerConfig>();
                return  new ProducerBuilder<Guid, byte[]>(config);
            });

            services.AddSingleton<IGroupIdFactory, GroupIdFactory>();
            services.AddSingleton<IBusProvider, KafkaBusProvider>();
            return services;
        }
    }
}
