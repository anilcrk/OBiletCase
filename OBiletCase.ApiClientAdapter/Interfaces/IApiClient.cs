using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter.Interfaces
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T data);
    }
}
