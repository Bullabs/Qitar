using Microsoft.Extensions.DependencyInjection;
using Qitar.Caching.DistributedCache.Extensions;
using System;

namespace Qitar.Caching.DistributedCache.Redis.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDistributedMemoryCache(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDistributedCache();
            services.AddStackExchangeRedisCache(options => { });

            return services;
        }
    }
}
