using Microsoft.Extensions.DependencyInjection;
using System;

namespace Qitar.Validation.FluentValidation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperRepository(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IValidationProvider, FluentValidationProvider>();

            return services;
        }
    }
}
