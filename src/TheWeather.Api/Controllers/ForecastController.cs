using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TheWeather.Api.Filters;
using TheWeather.Api.Request;
using TheWeather.Model.Entities;
using TheWeather.Service.Service;

namespace TheWeather.Api.Controllers
{
    /// <summary>
    /// Forecast сontroller
    /// </summary>
    [ApiController]
    [Route("forecast")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ForecastController : ControllerBase
    {
        /// <summary>
        /// Weather service
        /// </summary>
        private readonly IWeatherClient _weatherClient;

        /// <summary>
        /// Forecast
        /// </summary>
        /// <param name="weatherClient"></param>
        public ForecastController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        /// <summary>
        /// Get forecast weather for 5 days
        /// </summary>
        /// <param name="forecastViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidateModelState]
        [ProducesResponseType(typeof(IEnumerable<ForecastWeather>), 200)]
        public async Task<IActionResult> Get([FromQuery] ForecastRequest forecastViewModel)
        {
            var forecast = 
                await _weatherClient.GetWeekForecastAsync(forecastViewModel.City, forecastViewModel.Language, forecastViewModel.Unit);
            return Ok(forecast);
        }
    }
}
