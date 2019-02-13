using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TheWeather.Model.Entities;
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

        public Task<Weather> GetWeatherAsync(string city)
        {
            throw new NotImplementedException();
        }

        public Task<Weather> GetWeatherAsync(string city, string language)
        {
            throw new NotImplementedException();
        }

        public Task<Weather> GetWeatherAsync(string city, string language, string unit)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation IForecast interface

        public Task<Forecast> GetForecastAsync(string city)
        {
            throw new NotImplementedException();
        }

        public Task<Forecast> GetForecastAsync(string city, string language)
        {
            throw new NotImplementedException();
        }

        public Task<Forecast> GetForecastAsync(string city, string language, string unit)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
