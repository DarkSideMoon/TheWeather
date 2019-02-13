using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class BaseWeather
    {
        [JsonProperty("dt")]
        public long UnixDateTime { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(UnixDateTime).DateTime;

        [JsonProperty("main")]
        public MainWeather Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("weather")]
        public State State { get; set; }
    }
}
