using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TheWeather.Model.Entities;
using TheWeather.Model.Exceptions;
using TheWeather.Model.Infrastructure;
using TheWeather.Service.Builder;
using TheWeather.Service.Service;   

namespace TheWeather.Service.Clients
{
    public class OpenWeatherMapClient : IWeatherClient
    {
        private readonly WeatherSettings _weatherSettings;
        private readonly HttpClient _httpClient;

        public OpenWeatherMapClient(HttpClient httpClient, WeatherSettings weatherSettings)
        {
            _httpClient = httpClient;
            _weatherSettings = weatherSettings;
        }

        public async Task<Weather> GetWeatherAsync(string city, string language, string unit)
        {
            var weatherUrl = $"{_weatherSettings.BaseUrl}/{_weatherSettings.ApiVersion}/{_weatherSettings.WeatherUrl}";
            var query = new UrlBuilder(weatherUrl)
                .SetAppId(_weatherSettings.ApiKey)
                .SetCity(city)
                .SetLanguage(language)
                .SetUnit(unit)
                .Build();

            return await ExecuteRequest<Weather>(query).ConfigureAwait(false);
        }

        public async Task<Forecast> GetForecastAsync(string city, string language, string unit)
        {
            var forecastUrl = $"{_weatherSettings.BaseUrl}/{_weatherSettings.ApiVersion}/{_weatherSettings.ForecastUrl}";
            var query = new UrlBuilder(forecastUrl)
                .SetAppId(_weatherSettings.ApiKey)
                .SetCity(city)
                .SetLanguage(language)
                .SetUnit(unit)
                .Build();

            return await ExecuteRequest<Forecast>(query).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ForecastWeather>> GetWeekForecastAsync(string city, string language, string unit)
        {
            var allForecast = await GetForecastAsync(city, language, unit).ConfigureAwait(false);

            return allForecast.Forecasts
                .GroupBy(x => x.DayOfWeek)
                .Select(g => g.OrderByDescending(x => x.DateTime).FirstOrDefault())
                .ToList();
        }

        private async Task<TResult> ExecuteRequest<TResult>(string query)
        {
            var responseMessage = await _httpClient.GetAsync(query);
            try
            {
                if (responseMessage.StatusCode == HttpStatusCode.NotFound)
                    throw new CityNotFoundException();

                if (!responseMessage.IsSuccessStatusCode)
                    throw new WeatherClientException();

                var response = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(response);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
    }
}
