using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class Weather : BaseWeather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("sys")]
        public SystemWeather SystemWeather { get; set; }
    }
}
