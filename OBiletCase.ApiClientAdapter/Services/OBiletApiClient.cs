using OBiletCase.ApiClientAdapter.Helpers;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Models;
using OBiletCase.ApiClientAdapter.Models.RequestModels;
using OBiletCase.ApiClientAdapter.Models.ResponseModels;
using OBiletCase.Domain.Models;

namespace OBiletCase.ApiClientAdapter.Services
{
    public class OBiletApiClient : ApiClient, IOBiletApiClient
    {
        public OBiletApiClient(HttpClient client) : base(client)
        {
        }

        public async Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(BusLocationRequestModel request)
        {
            var requestModel = new BaseRequest<string>
            {
                Data = request.Query,
                DeviceSession = new DeviceSession
                {
                    DeviceId = request.DeviceSession.DeviceId,
                    SessionId = request.DeviceSession.SessionId
                },
                Language = request.Language
            };

            var apiResponse = await PostAsJsonAsync(Constants.ApUri.OBilet.GetBusLocations, requestModel);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var message = await apiResponse.Content.ReadAsStringAsync();

                throw new Exception(message);
            }

            var response = await apiResponse.Content.ReadAsJsonAsync<BaseResponse<List<BusLocationResponse>>>();

            return response;
        }

       public async Task<BaseResponse<DeviceSession>> GetSession(SessionRequestModel request)
        {
            var requestModel = new SessionRequest
            {
                Browser = new Models.RequestModels.Browser
                {
                    Name = request.Browser.Name,
                    Version = request.Browser.Version,
                },
                Connection = new Models.RequestModels.Connection
                {
                    IpAddress = request.Connection.IpAdress,
                    Port = request.Connection.Port
                },
                Type = request.Type,
            };

            var apiResponse = await PostAsJsonAsync(Constants.ApUri.OBilet.GetSession, requestModel);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var message = await apiResponse.Content.ReadAsStringAsync();

                throw new Exception(message);
            }

            var response = await apiResponse.Content.ReadAsJsonAsync<BaseResponse<DeviceSession>>();

            return response;
        }
    }
}
