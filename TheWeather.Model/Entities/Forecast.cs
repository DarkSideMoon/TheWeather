using Newtonsoft.Json;
using System.Collections.Generic;

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
