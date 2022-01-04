using System;

namespace TheWeather.Model.Exceptions
{
    public static class ExceptionExtensions
    {
        public static Exception DetailData(this Exception exception, in string key, in object value)
        {
            try
            {
                exception.Data[key] = ExceptionDataEntry.FromValue(value);
            }
            catch
            {
                // ignored, because we use it inside another exception catch block
                // so, we should avoid throwing a new exception to keep the original exception
            }

            return exception;
        }
    }
}
