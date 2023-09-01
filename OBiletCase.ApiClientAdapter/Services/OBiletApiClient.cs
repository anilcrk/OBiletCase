using Newtonsoft.Json;
using OBiletCase.ApiClientAdapter.Helpers;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Models.RequestModels;
using OBiletCase.ApiClientAdapter.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter.Services
{
    public class OBiletApiClient : ApiClient, IOBiletApiClient
    {
        public OBiletApiClient(HttpClient client) : base(client)
        {
            
        }

        public async Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(string searchValue, DateTime date)
        {
            var requestModel = new BaseRequest<string>
            {
                Data = searchValue,
                Date = date,
                DeviceSession = new DeviceSession
                {
                    SessionId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=",
                    DeviceId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA="
                },
                Language = "tr-TR"
            };

            var apiResponse = await PostAsJsonAsync(Constants.ApUri.OBilet.GetBusLocations, requestModel);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var exception = await apiResponse.Content.ReadAsJsonAsync<Exception>();

                throw exception;
            }

            var response = await apiResponse.Content.ReadAsJsonAsync<BaseResponse<List<BusLocationResponse>>>();

            return response;
        }
    }
}
