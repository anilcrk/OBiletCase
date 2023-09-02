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

        public async Task<DeviceSessionModel> GetSession(SessionRequestModel request)
        {
            var response = await _apiClient.GetSession(request);

            if (!response.Success)
            {
                throw new BusinessRuleException(response.ErrorExplanation);
            }

            return response;
        }
    }
}
