﻿using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }
    }
}
