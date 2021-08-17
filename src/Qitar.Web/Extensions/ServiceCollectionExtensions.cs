using CorrelationId.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Qitar.Web.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddVersioning();
            services.AddDefaultCorrelationId();

            return services;
        }

        internal static IServiceCollection AddVersioning(this IServiceCollection services)
        {

            return services;
        }
    }
}
