using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheWeather.Model.Infrastructure;
using TheWeather.Model.Interfaces;
using TheWeather.Model.Providers;

namespace TheWeather.Api.Extensions
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
        public static void AddWeatherClientService(this IServiceCollection services, IConfiguration Configuration)
        {
            var weatherSettings = Configuration.GetSection("WeatherSettings").Get<WeatherSettings>();

            services.AddTransient<IClient>(x => new OpenWeatherMap(weatherSettings));
        }
    }
}
