using System.ComponentModel.DataAnnotations;

namespace TheWeather.Api.Request
{
    /// <summary>
    /// Base data of view model
    /// </summary>
    public class BaseRequest
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
