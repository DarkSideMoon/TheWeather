using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWeather.Model.Extensions;

namespace TheWeather.Model.Builder
{
    /// <summary>
    /// Url builder for request
    /// </summary>
    public class UrlBuilder
    {
        private StringBuilder _urlBuilder;

        private Dictionary<string, string> _queryParams;

        public UrlBuilder(string baseUrl)
        {
            _queryParams = new Dictionary<string, string>();

            _urlBuilder = new StringBuilder();
            _urlBuilder.Append(baseUrl);
        }

        /// <summary>
        /// Set one param
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public UrlBuilder SetQueryParam(string name, string value)
        {
            _queryParams.Add(name, value);
            return this;
        }

        /// <summary>
        /// Set parameters query api
        /// </summary>
        /// <param name="values"></param>
        public UrlBuilder SetQueryParams(Dictionary<string, string> values)
        {
            foreach (var kv in values)
                _queryParams.Add(kv.Key, kv.Value);

            return this;
        }

        /// <summary>
        /// Set parameters query api from object
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public UrlBuilder SetQueryParams(object values)
        {
            foreach (var kv in values.ToKeyValuePairs())
                _queryParams.Add(kv.Key, kv.Value.ToString());

            return this;
        }


        /// <summary>
        /// Build all url
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            if (_queryParams.Any())
            {
                _urlBuilder.Append("?");
                foreach (var queryParam in _queryParams)
                {
                    string query = $"{queryParam.Key}={queryParam.Value}";

                    if (_queryParams.LastOrDefault().Key != queryParam.Key)
                        query += "&";

                    _urlBuilder.Append(query);
                }
            }

            return _urlBuilder.Replace(" ", "").ToString();
        }
    }
}
