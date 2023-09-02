using Newtonsoft.Json;
using OBiletCase.ApiClientAdapter.Helpers;
using OBiletCase.ApiClientAdapter.Interfaces;
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

namespace OBiletCase.ApiClientAdapter.Services
{
    public class OBiletApiClient : ApiClient, IOBiletApiClient
    {
        private DeviceSession _deviceSession;
        public OBiletApiClient(HttpClient client) : base(client)
        {
        }

        public async Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(BusLocationRequestModel request)
        {
            await SetDeviceSession(request.Session);

            var requestModel = new BaseRequest<string>
            {
                Data = request.SearchValue,
                Date = request.Date,
                DeviceSession = _deviceSession,
                Language = request.Language
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

        // TODO : SessionPO yerine request model olmalı
        // will add cache control
        private async Task SetDeviceSession(SessionPO session)
        {
            var requestModel = new SessionRequest
            {
                Browser = new Browser
                {
                    Name = session.Browser.Name,
                    Version = session.Browser.Version,
                },
                Connection = new Connection
                {
                    IpAddress = session.Connection.IpAdress,
                    Port = session.Connection.Port
                },
                Type = session.Type,
            };

            var apiResponse = await PostAsJsonAsync(Constants.ApUri.OBilet.GetSession, requestModel);

            if (apiResponse.IsSuccessStatusCode)
            {
                var deviceSession = await apiResponse.Content.ReadAsJsonAsync<DeviceSession>();

                _deviceSession = deviceSession;
            }
        }
    }
}
