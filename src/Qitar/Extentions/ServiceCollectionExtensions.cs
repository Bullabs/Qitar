using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qitar.Caching;
using Qitar.Commands;
using Qitar.Cryptography;
using Qitar.Events;
using Qitar.Jobs;
using Qitar.Messages;
using Qitar.Queries;
using Qitar.Serialization;
using Qitar.Utils.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Qitar
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQitar(this IServiceCollection services, params Type[] types)
        {

            services.AddSerializer();

            var typeList = types.ToList();

            services.Scan(s => s.FromAssembliesOf(typeList)
               .AddClasses()
               .AsImplementedInterfaces());

            services
                .AddMapping(typeList)
                .AddSerializer()
                .AddCaching()
                .AddJobs()
                .AddCryptography()
                .AddSystemInfo();
            
            return services;
        }


        private static IServiceCollection AddSerializer(this IServiceCollection services)
        {
            services.AddOptions<SerializerOptions>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("Qitar.Serializer").Bind(settings);
            });

            services.AddTransient<ISerializer, Serializer>();

            return services;
        }

        private static IServiceCollection AddCaching(this IServiceCollection services)
        {
           services.AddOptions<CacheOptions>().Configure<IConfiguration>((settings, configuration) =>
           {
               configuration.GetSection("Qitar.Caching").Bind(settings);
           });

            services.AddTransient<ICacheService, CacheService>();

            return services;
        }

        private static IServiceCollection AddCryptography(this IServiceCollection services)
        {
            services.AddSingleton<IEncryptor, Encryptor>();
            services.AddSingleton<IHasher, Hasher>();

            return services;
        }

        private static IServiceCollection AddSystemInfo(this IServiceCollection services)
        {
            services.AddSingleton<ISystemInfo, SystemInfo>();

            return services;
        }

        private static IServiceCollection AddJobs(this IServiceCollection services)
        {
            services.AddSingleton<IJobRunner, JobRunner>();

            return services;
        }

        private static IServiceCollection AddMapping(this IServiceCollection services, IEnumerable<Type> types)
        {

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var config = new TypeAdapterConfig();

            foreach (var type in types)
            {
                var typesToMap = type.Assembly.GetTypes().Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && (
                        typeof(ICommand).IsAssignableFrom(t) ||
                        typeof(IEvent).IsAssignableFrom(t) ||
                        typeof(IMessage).IsAssignableFrom(t) ||
                        typeof(IQuery<>).IsAssignableFrom(t)))
                        .ToList();

                foreach (var typeToMap in typesToMap)
                {
                    config.NewConfig(typeToMap, typeToMap);
                }
            }

            services.AddSingleton(config);

            return services;
        }
    }
}
