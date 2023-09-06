using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter.Interfaces
{
    public interface IApiClient
    {
        /// <summary>
        /// Serialises the data and posts it to the sent url.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data);
    }
}
