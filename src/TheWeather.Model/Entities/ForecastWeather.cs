using Newtonsoft.Json;
using System;

namespace TheWeather.Model.Entities
{
    public class ForecastWeather : BaseWeather
    {
        [JsonProperty("dayOfWeek")]
        public string DayOfWeek => DateTime.DayOfWeek.ToString();
    }
}
