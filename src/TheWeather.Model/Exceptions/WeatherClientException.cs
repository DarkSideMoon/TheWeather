using System;
using System.Net;

namespace TheWeather.Model.Exceptions
{
    /// <summary>
    /// Custom exception with status code
    /// </summary>
    [Serializable]
    public class WeatherClientException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public WeatherClientException()
        {
        }

        public WeatherClientException(string name, HttpStatusCode statusCode)
            : base(name)
        {
            StatusCode = statusCode;
        }
    }
}
