using Microsoft.Extensions.DependencyInjection;
using Qitar.Serialization;
using System;

namespace Qitar.Serializer.Text.Json.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTextJsonSerializer(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<ISerializerProvider, TextJsonProvider>();

            return services;
        }
    }
}
