using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TheWeather.Model.Entities
{
    public class State
    {
        [JsonProperty("main")]
        public string MainWeather { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        private string _icon;

        [JsonProperty("icon")]
        public string Icon
        {
            get => $"https://openweathermap.org/img/w/{_icon}.png";
            set => _icon = value;
        }
    }
}
