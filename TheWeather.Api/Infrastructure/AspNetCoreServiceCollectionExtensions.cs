using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace TheWeather.Api.Infrastructure
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        private const string _httpClientName = "httpService";

        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient(_httpClientName);
            services.AddTransient(x => x.GetRequiredService<IHttpClientFactory>().CreateClient(_httpClientName));

            return services;
        }
    }
}
