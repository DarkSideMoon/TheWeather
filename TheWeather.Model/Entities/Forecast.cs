using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class Forecast
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("list")]
        public IEnumerable<ForecastWeather> Forecasts { get; set; }
    }
}
