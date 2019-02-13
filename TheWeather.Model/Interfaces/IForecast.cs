using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheWeather.Model.Entities;

namespace TheWeather.Model.Interfaces
{
    public interface IForecast
    {
        Task<Forecast> GetForecastAsync(string city);

        Task<Forecast> GetForecastAsync(string city, string language);

        Task<Forecast> GetForecastAsync(string city, string language, string unit);
    }
}
