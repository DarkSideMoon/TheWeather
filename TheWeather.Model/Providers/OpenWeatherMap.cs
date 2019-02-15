using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TheWeather.Model.Builder;
using TheWeather.Model.Entities;
using TheWeather.Model.Extensions;
using TheWeather.Model.Infrastructure;
using TheWeather.Model.Interfaces;

namespace TheWeather.Model.Providers
{
    /// <summary>
    /// Implementation interface of IClient for https://openweathermap.org service
    /// </summary>
    public class OpenWeatherMap : IClient
    {
        private readonly WeatherSettings _weatherSettings;

        private readonly RestClient _restClient;

        public OpenWeatherMap(WeatherSettings weatherSettings)
        {
            _weatherSettings = weatherSettings;

            _restClient = new RestClient(_weatherSettings.BaseUrl);
        }

        #region Implementation IWeather interface

        public async Task<Weather> GetWeatherAsync(string city)
        {
            string query = new UrlBuilder("data/2.5/weather")
                .SetQueryParams(new
                {
                    q = city,
                    appid = _weatherSettings.ApiKey
                })
                .Build();

            return await _restClient.ExecuteByQuery<Weather>(query);
        }

        public async Task<Weather> GetWeatherAsync(string city, string language)
        {
            string query = new UrlBuilder("data/2.5/weather")
                .SetQueryParams(new
                {
                    q = city,
                    appid = _weatherSettings.ApiKey,
                    lang = language
                })
                .Build();

            return await _restClient.ExecuteByQuery<Weather>(query);
        }

        public async Task<Weather> GetWeatherAsync(string city, string language, string unit)
        {
            string query = new UrlBuilder("data/2.5/weather")
                .SetQueryParams(new
                {
                    q = city,
                    appid = _weatherSettings.ApiKey,
                    lang = language,
                    units = unit
                })
                .Build();

            return await _restClient.ExecuteByQuery<Weather>(query);
        }

        #endregion

        #region Implementation IForecast interface

        public async Task<Forecast> GetForecastAsync(string city)
        {
            string query = new UrlBuilder("data/2.5/forecast")
                .SetQueryParams(new
                {
                    q = city,
                    appid = _weatherSettings.ApiKey
                })
                .Build();

            return await _restClient.ExecuteByQuery<Forecast>(query);
        }

        public async Task<Forecast> GetForecastAsync(string city, string language)
        {
            string query = new UrlBuilder("data/2.5/forecast")
                .SetQueryParams(new
                {
                    q = city,
                    appid = _weatherSettings.ApiKey,
                    lang = language
                })
                .Build();

            return await _restClient.ExecuteByQuery<Forecast>(query);
        }

        public async Task<Forecast> GetForecastAsync(string city, string language, string unit)
        {
            string query = new UrlBuilder("data/2.5/forecast")
                .SetQueryParams(new
                {
                    q = city,
                    appid = _weatherSettings.ApiKey,
                    lang = language,
                    units = unit
                })
                .Build();

            return await _restClient.ExecuteByQuery<Forecast>(query);
        }

        public async Task<IEnumerable<ForecastWeather>> GetWeekForecastAsync(string city, string language, string unit)
        {
            var allForecast = await GetForecastAsync(city, language, unit);

            var weekForectas = allForecast.Forecasts
                .GroupBy(x => x.DayOfWeek)
                .Select(g => g.OrderByDescending(x => x.DateTime).FirstOrDefault())
                .ToList();

            return weekForectas;
        }

        #endregion
    }
}
