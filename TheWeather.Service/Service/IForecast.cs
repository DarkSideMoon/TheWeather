using System.Collections.Generic;
using System.Threading.Tasks;
using TheWeather.Model.Entities;

namespace TheWeather.Service.Service
{
    public interface IForecast
    {
        Task<Forecast> GetForecastAsync(string city, string language, string unit);

        Task<IEnumerable<ForecastWeather>> GetWeekForecastAsync(string city, string language, string unit);
    }
}
