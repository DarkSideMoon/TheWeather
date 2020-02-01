using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using TheWeather.Api.Filters;
using TheWeather.Api.Request;
using TheWeather.Model.Entities;
using TheWeather.Model.Interfaces;

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
        private readonly IClient _weatherService;

        /// <summary>
        /// Weather
        /// </summary>
        /// <param name="weatherService"></param>
        public WeatherController(IClient weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get weather
        /// </summary>
        /// <param name="weatherViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(typeof(Weather), 200)]
        public async Task<IActionResult> Get([FromBody] WeatherRequest weatherViewModel)
        {
            var weather = 
                await _weatherService.GetWeatherAsync(weatherViewModel.City, weatherViewModel.Language, weatherViewModel.Unit);
            return Ok(weather);
        }
    }
}
