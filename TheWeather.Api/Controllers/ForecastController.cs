using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using TheWeather.Api.Filters;
using TheWeather.Api.Request;
using TheWeather.Model.Entities;
using TheWeather.Model.Interfaces;

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
        private readonly IClient _weatherService;

        /// <summary>
        /// Forecast
        /// </summary>
        /// <param name="weatherService"></param>
        public ForecastController(IClient weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get forecast weather for 5 days
        /// </summary>
        /// <param name="forecastViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(typeof(IEnumerable<ForecastWeather>), 200)]
        public async Task<IActionResult> Get([FromBody] ForecastRequest forecastViewModel)
        {
            var forecast = 
                await _weatherService.GetWeekForecastAsync(forecastViewModel.City, forecastViewModel.Language, forecastViewModel.Unit);
            return Ok(forecast);
        }
    }
}
