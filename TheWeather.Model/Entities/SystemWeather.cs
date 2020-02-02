using Newtonsoft.Json;
using System;

namespace TheWeather.Model.Entities
{
    public class SystemWeather
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }

        [JsonProperty("sunriseDateTime")]
        public DateTime SunriseDateTime => DateTimeOffset.FromUnixTimeSeconds(Sunrise).DateTime;

        [JsonProperty("sunsetDateTime")]
        public DateTime SunsetDateTime => DateTimeOffset.FromUnixTimeSeconds(Sunset).DateTime;
    }
}
