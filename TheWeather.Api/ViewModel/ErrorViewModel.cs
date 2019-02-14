using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheWeather.Api.ViewModel
{
    public class ErrorViewModel
    {
        [JsonProperty("info")]
        public string Information { get; set; }

        [JsonProperty("actionName")]
        public string ActionName { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("trace")]
        public string StackTrace { get; set; }


        public string BuildJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
