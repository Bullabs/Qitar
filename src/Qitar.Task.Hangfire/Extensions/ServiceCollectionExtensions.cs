using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Qitar.Task.Hangfire.Extensions
{
   public static  class ServiceCollectionExtensions
    {

        public static IServiceCollection AddHangfire(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<IBackgroundJobClient>(new BackgroundJobClient());
            services.AddSingleton<IRecurringJobManager>(new RecurringJobManager());

            return services;
        }
    }
}
