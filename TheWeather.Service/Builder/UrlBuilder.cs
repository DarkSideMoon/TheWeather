using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWeather.Model.Common;

namespace TheWeather.Service.Builder
{
    public class UrlBuilder : IUrlBuilder
    {
        private readonly StringBuilder _urlBuilder;

        /// <summary>
        /// Dictionary faster than NameValueCollection 
        /// https://www.dotnetperls.com/namevaluecollection
        /// </summary>
        private readonly Dictionary<string, string> _queryParams = new Dictionary<string, string>();

        public UrlBuilder(string baseUrl)
        {
            _urlBuilder = new StringBuilder();
            _urlBuilder.Append(baseUrl);
        }

        public IUrlBuilder SetAppId(string apiKey)
        {
            _queryParams.Add(Constants.Weather.AppId, apiKey);
            return this;
        }

        public IUrlBuilder SetCity(string city)
        {
            _queryParams.Add(Constants.Weather.City, city);
            return this;
        }

        public IUrlBuilder SetLanguage(string language)
        {
            _queryParams.Add(Constants.Weather.Language, language);
            return this;
        }

        public IUrlBuilder SetUnit(string unit)
        {
            _queryParams.Add(Constants.Weather.Unit, unit);
            return this;
        }

        /// <summary>
        /// Set parameters query api from object
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public IUrlBuilder SetQueryParams(object values)
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
            _urlBuilder.Append("?");
            foreach (var queryParam in _queryParams)
            {
                if (string.IsNullOrEmpty(queryParam.Value))
                    continue;

                string query = $"{queryParam.Key}={queryParam.Value}";

                if (_queryParams.LastOrDefault().Key != queryParam.Key)
                    query += "&";

                _urlBuilder.Append(query);
            }

            return _urlBuilder.Replace(" ", "").ToString();
        }
    }
}
