using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TheWeather.Model.Entities;

namespace TheWeather.Model.Extensions
{
    public static class RestSharpExtensions
    {
        public static async Task<T> ExecuteByQuery<T>(this RestClient restClient, string query)
        {
            RestRequest request = new RestRequest(query, Method.GET);
            try
            {
                IRestResponse<T> response = await restClient.ExecuteTaskAsync<T>(request);
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
