﻿using System.Collections.Generic;

namespace TheWeather.Service.Builder
{
    public static class UrlBuilderExtensions
    {
        public static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairs(this object obj)
        {
            var inputObject = obj.ToString();
            var arrayObjects = inputObject
                .Replace("{", "")
                .Replace("}", "")
                .Trim()
                .Split(',');

            foreach (var str in arrayObjects)
            {
                var keyValue = str.Trim();
                var keyValueArray = keyValue.Split('=');

                var key = keyValueArray[0];
                var value = keyValueArray[1];

                yield return new KeyValuePair<string, object>(key, value);
            }
        }
    }
}
