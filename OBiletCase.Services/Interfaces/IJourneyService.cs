using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;

namespace OBiletCase.Services.Interfaces
{
    public interface IJourneyService
    {
        /// <summary>
        /// Fetches a list of bus journeys based on the given request model asynchronously.
        /// </summary>
        /// <param name="request">The request model containing criteria for bus journey search.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of bus journeys.</returns>
        Task<List<BusJourneyDTO>> GetBusJourneys(BusJourneyRequestModel request);
    }
}
