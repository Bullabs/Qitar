using Microsoft.Extensions.DependencyInjection;
using Qitar.Utils;
using Qitar.Web.Swagger;
using System;

namespace Qitar.Web.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQitarWeb(this IServiceCollection services)
        {
            services.NotNull();

            services.AddVersioning();
            services.AddSwagger();

            return services;
        }

        internal static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            return services.AddApiVersioning();
        }

        internal static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DocumentFilter<ConcealedApiFilter>();
            });

            return services;

        }
    }
}