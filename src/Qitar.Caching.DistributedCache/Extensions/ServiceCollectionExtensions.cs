using Microsoft.Extensions.DependencyInjection;
using System;

namespace Qitar.Caching.DistributedCache.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDistributedCache(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<ICacheProvider, DistributedCacheProvider>();

            return services;
        }
    }
}
