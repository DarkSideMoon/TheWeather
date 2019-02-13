using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
