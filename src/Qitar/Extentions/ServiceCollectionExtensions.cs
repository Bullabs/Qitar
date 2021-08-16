using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qitar.Caching;
using Qitar.Commands;
using Qitar.Events;
using Qitar.Queries;
using Qitar.Serialization;
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
            
            services.AddMapping(typeList).AddSerializer().AddCaching();
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
