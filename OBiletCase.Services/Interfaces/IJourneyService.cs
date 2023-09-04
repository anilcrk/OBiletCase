using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;

namespace OBiletCase.Services.Interfaces
{
    public interface IJourneyService
    {
        Task<List<BusJourneyDTO>> GetBusJourneys(BusJourneyRequestModel request);
    }
}
