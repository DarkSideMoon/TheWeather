using Microsoft.Extensions.DependencyInjection;
using TheWeather.Model.Interfaces;
using TheWeather.Model.Providers;

namespace TheWeather.Api.Infrastructure
{
    /// <summary>
    /// Provie extensions for DI
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Add movie client service through DI
        /// </summary>
        /// <param name="services"></param>
        public static void AddWeatherClientService(this IServiceCollection services)
        {
            services.AddTransient<IClient, OpenWeatherMap>();
        }
    }
}
