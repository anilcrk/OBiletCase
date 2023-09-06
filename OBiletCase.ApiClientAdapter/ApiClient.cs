using Newtonsoft.Json;
using OBiletCase.ApiClientAdapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter
{
    public class ApiClient : IApiClient
    {
        protected readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Posts a JSON-serialized object to the specified URL.
        /// </summary>
        /// <typeparam name="T">The type of the data being serialized.</typeparam>
        /// <param name="url">The URL to post the data to.</param>
        /// <param name="data">The object data to post.</param>
        /// <returns>A task that represents the asynchronous post operation. The task result contains the HTTP response.</returns>
        public Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);

            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return _client.PostAsync(url, content);
        }
    }
}
