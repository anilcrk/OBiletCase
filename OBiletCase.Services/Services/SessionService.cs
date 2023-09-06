using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Exceptions;
using OBiletCase.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Services.Services
{
    public class SessionService : ISessionService
    {
        private readonly IOBiletApiClient _apiClient;
        public SessionService(IOBiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Retrieves device session information based on the provided request model.
        /// </summary>
        /// <param name="request">The request model containing the necessary information for retrieving the device session.</param>
        /// <returns>A task representing the operation, which returns a DeviceSessionModel object.</returns>
        public async Task<DeviceSessionModel> GetDeviceSession(SessionRequestModel request)
        {
            var response = await _apiClient.GetSession(request);

            if(response.Status != ApiClientAdapter.Enums.StatusType.Success)
            {
                throw new BusinessRuleException(response.UserMessage);
            }

            return new DeviceSessionModel
            {
                DeviceId = response.ResponseData.DeviceId,
                SessionId = response.ResponseData.SessionId
            };
        }
    }
}
