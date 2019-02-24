using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TheWeather.Model.Infrastructure;
using TheWeather.Model.Interfaces;
using TheWeather.Model.Providers;
using Microsoft.Extensions.DependencyInjection;
using TheWeather.Api.Filters;
using TheWeather.Api.ViewModel;
using TheWeather.Model.Entities;

namespace TheWeather.Api.Controllers
{
    /// <summary>
    /// Weather controller
    /// </summary>
    [EnableCors("Cors")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        /// <summary>
        /// Weather service
        /// </summary>
        private readonly IClient _weatherService;

        /// <summary>
        /// Weather
        /// </summary>
        /// <param name="serviceProvider"></param>
        public WeatherController(IServiceProvider serviceProvider)
        {
            _weatherService = serviceProvider.GetService<IClient>();
        }


        /// <summary>
        /// Get weather
        /// </summary>
        /// <param name="weatherViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [CustomExceptionFilter]
        [ProducesResponseType(typeof(Weather), 200)]
        public async Task<IActionResult> Get([FromBody] WeatherViewModel weatherViewModel)
        {
            var weather = 
                await _weatherService.GetWeatherAsync(weatherViewModel.City, weatherViewModel.Language, weatherViewModel.Unit);
            return Ok(weather);
        }
    }
}
