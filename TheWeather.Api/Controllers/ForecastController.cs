using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TheWeather.Api.Filters;
using TheWeather.Api.ViewModel;
using TheWeather.Model.Entities;
using TheWeather.Model.Interfaces;

namespace TheWeather.Api.Controllers
{
    /// <summary>
    /// Forecast сontroller
    /// </summary>
    [EnableCors("Cors")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ForecastController : Controller
    {
        /// <summary>
        /// Weather service
        /// </summary>
        private readonly IClient _weatherService;

        /// <summary>
        /// Forecast
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ForecastController(IServiceProvider serviceProvider)
        {
            _weatherService = serviceProvider.GetService<IClient>();
        }

        /// <summary>
        /// Get forecast weather for 5 days
        /// </summary>
        /// <param name="forecastViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(IEnumerable<ForecastWeather>), 200)]
        public async Task<IActionResult> Get([FromBody] ForecastViewModel forecastViewModel)
        {
            var forecast = 
                await _weatherService.GetWeekForecastAsync(forecastViewModel.City, forecastViewModel.Language, forecastViewModel.Unit);
            return Ok(forecast);
        }
    }
}
