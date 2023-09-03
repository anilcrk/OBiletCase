using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;

namespace OBiletCase.Services.Interfaces
{
    public interface IBusJourneyService
    {
        Task<List<BusJourneyDTO>> GetBusJourneys(BusJourneyRequestModel request);
    }
}
