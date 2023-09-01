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

        public Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);

            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return _client.PostAsync(url, content);
        }
    }
}
