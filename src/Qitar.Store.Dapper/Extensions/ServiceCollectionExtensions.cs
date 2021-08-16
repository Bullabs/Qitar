using Microsoft.Extensions.DependencyInjection;
using Qitar.Repositories;
using System;

namespace Qitar.Store.Dapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped(typeof(IRepository<>),typeof(DapperRepository<>));

            return services;
        }
    }
}