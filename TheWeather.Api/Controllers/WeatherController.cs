using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using TheWeather.Api.Filters;
using TheWeather.Api.Request;
using TheWeather.Model.Entities;
using TheWeather.Service.Service;

namespace TheWeather.Api.Controllers
{
    /// <summary>
    /// Weather controller
    /// </summary>
    [ApiController]
    [Route("weather")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WeatherController : ControllerBase
    {
        /// <summary>
        /// Weather service
        /// </summary>
        private readonly IWeatherClient _weatherClient;

        /// <summary>
        /// Weather
        /// </summary>
        /// <param name="weatherClient"></param>
        public WeatherController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        /// <summary>
        /// Get weather
        /// </summary>
        /// <param name="weatherViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidateModelState]
        [ProducesResponseType(typeof(Weather), 200)]
        public async Task<IActionResult> Get([FromQuery] WeatherRequest weatherViewModel)
        {
            var weather = 
                await _weatherClient.GetWeatherAsync(weatherViewModel.City, weatherViewModel.Language, weatherViewModel.Unit);
            return Ok(weather);
        }
    }
}
