using Microsoft.Extensions.DependencyInjection;
using TheWeather.Service.Clients;
using TheWeather.Service.Service;

namespace TheWeather.Api.Infrastructure
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient<IWeatherClient, OpenWeatherMapClient>();
            return services;
        }
    }
}
