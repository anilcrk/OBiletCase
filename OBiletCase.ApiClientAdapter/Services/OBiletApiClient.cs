using Newtonsoft.Json;
using OBiletCase.ApiClientAdapter.Helpers;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Models;
using OBiletCase.ApiClientAdapter.Models.RequestModels;
using OBiletCase.ApiClientAdapter.Models.ResponseModels;
using OBiletCase.Domain.Models;
using OBiletCase.Domain.ParameterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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
                Data = request.SearchValue,
                Date = request.Date,
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

       public async Task<DeviceSessionModel> GetSession(SessionRequestModel request)
        {
            var requestModel = new SessionRequest
            {
                Browser = new Browser
                {
                    Name = request.Browser.Name,
                    Version = request.Browser.Version,
                },
                Connection = new Connection
                {
                    IpAddress = request.Connection.IpAdress,
                    Port = request.Connection.Port
                },
                Type = request.Type,
            };

            var apiResponse = await PostAsJsonAsync(Constants.ApUri.OBilet.GetSession, request);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var message = await apiResponse.Content.ReadAsStringAsync();

                throw new Exception(message);
            }

            var response = await apiResponse.Content.ReadAsJsonAsync<DeviceSession>();

            return new DeviceSessionModel
            {
                DeviceId = response.DeviceId,
                SessionId = response.SessionId,
            };
        }
    }
}
