using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheWeather.Model.Entities;

namespace TheWeather.Model.Interfaces
{
    public interface IWeather
    {
        Task<Weather> GetWeatherAsync(string city);

        Task<Weather> GetWeatherAsync(string city, string language);

        Task<Weather> GetWeatherAsync(string city, string language, string unit);
    }
}
