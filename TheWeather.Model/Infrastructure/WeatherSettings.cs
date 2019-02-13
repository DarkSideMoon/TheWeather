using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeather.Model.Infrastructure
{
    public class WeatherSettings
    {
        /// <summary>
        /// Key of application openweathermap
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Base url of api openweathermap
        /// </summary>
        public string BaseUrl { get; set; }
    }
}
