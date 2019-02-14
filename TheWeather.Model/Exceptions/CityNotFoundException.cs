using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeather.Model.Exceptions
{
    /// <summary>
    /// Custom exception if city not found
    /// </summary>
    [Serializable]
    public class CityNotFoundException : Exception
    {
        public CityNotFoundException()
        {
        }
    }
}
