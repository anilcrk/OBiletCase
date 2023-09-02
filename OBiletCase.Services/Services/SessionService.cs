using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.Domain.Models;
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

        public Task<DeviceSessionModel> GetSession(SessionRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
