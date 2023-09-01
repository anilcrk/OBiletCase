using Newtonsoft.Json;

namespace OBiletCase.ApiClientAdapter.Helpers
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Deserializing and mapping json string to model which given as generic type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(dataAsString);
        }
    }
}
