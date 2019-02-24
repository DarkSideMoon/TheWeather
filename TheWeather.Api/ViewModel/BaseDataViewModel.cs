using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWeather.Api.ViewModel
{
    /// <summary>
    /// Base data of view model
    /// </summary>
    public class BaseDataViewModel
    {
        /// <summary>
        /// City of weather
        /// </summary>
        [Required(ErrorMessage = "City is required parameter")]
        public string  City { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; } = "en";

        /// <summary>
        /// Metric of weather
        /// </summary>
        public string Unit { get; set; } = "metric";
    }
}
