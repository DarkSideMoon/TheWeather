using TheWeather.Model.Entities;
using System.Threading.Tasks;

namespace TheWeather.Service.Service
{
    public interface IWeather
    {
        Task<Weather> GetWeatherAsync(string city, string language, string unit);
    }
}
