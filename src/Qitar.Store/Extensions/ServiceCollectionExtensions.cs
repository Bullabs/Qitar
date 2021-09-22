using Microsoft.Extensions.DependencyInjection;
using Qitar.Utils;

namespace Qitar.Store.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStore(this IServiceCollection services)
        {
            services.NotNull();

            return services;
        }
    }
}