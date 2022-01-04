using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TheWeather.Model.Exceptions
{
    /// <summary>
    /// Defines a value/json pair to represent an exception data value as JSON
    /// </summary>
    public record ExceptionDataEntry
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            WriteIndented = true
        };

        private ExceptionDataEntry(in object value, in string json)
        {
            Value = value;
            Json = json;
        }

        public object Value { get; }
        public string Json { get; }

        public static ExceptionDataEntry FromValue(in object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var json = JsonSerializer.Serialize(value, SerializerOptions);
            return new ExceptionDataEntry(value, json);
        }

        /// <summary>
        ///  Represents an exception data value as JSON
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Json;
        }
    }
}
