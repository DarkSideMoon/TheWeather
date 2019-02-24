using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TheWeather.Model.Exceptions
{
    /// <summary>
    /// Custom exception with status code
    /// </summary>
    [Serializable]
    public class ResponseStatusException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ResponseStatusException()
        {
        }

        public ResponseStatusException(string name, HttpStatusCode statusCode)
            : base(name)
        {
            StatusCode = statusCode;
        }
    }
}
