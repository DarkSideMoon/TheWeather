using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class Weather : BaseWeather
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }
    }
}
