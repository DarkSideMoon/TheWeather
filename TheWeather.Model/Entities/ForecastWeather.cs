using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class ForecastWeather : BaseWeather
    {
        [JsonProperty("dayOfWeek")]
        public string DayOfWeek => DateTime.DayOfWeek.ToString();
    }
}
