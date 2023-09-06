using OBiletCase.ApiClientAdapter.Helpers;
using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Models;
using OBiletCase.ApiClientAdapter.Models.RequestModels;
using OBiletCase.ApiClientAdapter.Models.ResponseModels;
using OBiletCase.Domain.Models;
using System.Xml;

namespace OBiletCase.ApiClientAdapter.Services
{
    public class OBiletApiClient : ApiClient, IOBiletApiClient
    {
        public OBiletApiClient(HttpClient client) : base(client)
        {
        }

        // <summary>
        /// Retrieves bus locations based on the query.
        /// </summary>
        /// <param name="request">Bus location request model.</param>
        /// <returns>A task with bus location responses.</returns>
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

        /// <summary>
        /// Gets the device session details.
        /// </summary>
        /// <param name="request">Session request model.</param>
        /// <returns>A task with device session details.</returns>
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

        /// <summary>
        /// Retrieves bus journey details.
        /// </summary>
        /// <param name="request">Bus journey request model.</param>
        /// <returns>A task with journey responses.</returns>
        public async Task<BaseResponse<List<JourneyResponse>>> GetBusJourneys(BusJourneyRequestModel request)
        {
            var requestModel = new BaseRequest<BusJourneyRequest>
            {
                Data = new BusJourneyRequest
                {
                    OriginId = request.OriginId,
                    DestinationId = request.DestinationId,
                    DepartureDate = request.DepartureDate.Date.ToString("yyyy-MM-dd")
                },
                DeviceSession = new DeviceSession
                {
                    DeviceId = request.DeviceSession.DeviceId,
                    SessionId = request.DeviceSession.SessionId
                },
                Language = request.Language,
            };

            var apiResponse = await PostAsJsonAsync(Constants.ApUri.OBilet.GetBusJourneys, requestModel);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var message = await apiResponse.Content.ReadAsStringAsync();

                throw new Exception(message);
            }

            var response = await apiResponse.Content.ReadAsJsonAsync<BaseResponse<List<JourneyResponse>>>();

            return response;
        }
    }
}
