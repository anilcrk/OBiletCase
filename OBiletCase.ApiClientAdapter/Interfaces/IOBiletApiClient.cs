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
        /// <summary>
        /// Fetches bus locations.
        /// </summary>
        /// <param name="request">Bus location request model.</param>
        /// <returns>A task with bus location responses.</returns>
        Task<BaseResponse<List<BusLocationResponse>>> GetBusLocations(BusLocationRequestModel request);

        /// <summary>
        /// Retrieves device session.
        /// </summary>
        /// <param name="request">Session request model.</param>
        /// <returns>A task with device session details.</returns>
        Task<BaseResponse<DeviceSession>> GetSession(SessionRequestModel request);

        /// <summary>
        /// Gets bus journey details.
        /// </summary>
        /// <param name="request">Bus journey request model.</param>
        /// <returns>A task with journey responses.</returns>
        Task<BaseResponse<List<JourneyResponse>>> GetBusJourneys(BusJourneyRequestModel request);
    }
}
