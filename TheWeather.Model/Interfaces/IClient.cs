using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeather.Model.Interfaces
{
    public interface IClient : IWeather, IForecast
    {
    }
}
