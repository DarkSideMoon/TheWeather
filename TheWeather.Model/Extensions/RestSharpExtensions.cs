using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TheWeather.Model.Entities;
using TheWeather.Model.Exceptions;

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

                if (response.IsSuccessful)
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(response.Content));

                if (response.StatusCode == HttpStatusCode.NotFound)
                    throw new CityNotFoundException();

                throw new ResponseStatusException(response.StatusDescription, response.StatusCode);
            }
            catch (CityNotFoundException cityNotFoundException)
            {
                throw cityNotFoundException;
            }
            catch (ResponseStatusException responseStatusException)
            {
                throw responseStatusException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
