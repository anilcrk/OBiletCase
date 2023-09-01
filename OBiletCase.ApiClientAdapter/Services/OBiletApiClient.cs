using Newtonsoft.Json;
using OBiletCase.ApiClientAdapter.Helpers;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.Domain.Models.RequestModels;
using OBiletCase.Domain.Models.ResponseModels;
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

        public async Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(BaseRequest<string> requestModel)
        {
            var response = await PostAsJsonAsync(Constants.ApUri.OBilet.GetBusLocations, requestModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsJsonAsync<BaseResponse<List<BusLocationResponse>>>();
            }
        }
    }
}
