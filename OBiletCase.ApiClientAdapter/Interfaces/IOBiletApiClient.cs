using OBiletCase.ApiClientAdapter.Models;
using OBiletCase.ApiClientAdapter.Models.RequestModels;
using OBiletCase.ApiClientAdapter.Models.ResponseModels;
using OBiletCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.ApiClientAdapter.Interfaces
{
    public interface IOBiletApiClient
    {
        Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(BusLocationRequestModel request);

        Task<BaseResponse<DeviceSession>> GetSession(SessionRequestModel request);

        Task<BaseResponse<JourneyResponse>> GetBusJourneys(BusJourneyRequestModel request);
    }
}
