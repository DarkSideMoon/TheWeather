using Microsoft.Extensions.DependencyInjection;
using TheWeather.Service.Clients;
using TheWeather.Service.Service;

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
        public static IServiceCollection AddWeatherClientService(this IServiceCollection services)
        {
            services.AddTransient<IWeatherClient, OpenWeatherMapClient>();
            return services;
        }
    }
}
