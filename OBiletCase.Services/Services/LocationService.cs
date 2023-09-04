using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Enums;
using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Exceptions;
using OBiletCase.Services.Interfaces;

namespace OBiletCase.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly IOBiletApiClient _apiClient;

        public LocationService(IOBiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<SelectListItemDTO>> GetBusLoacations(BusLocationRequestModel request)
        {
            var response = await _apiClient.GetBusLocations(request);

            if(response.Status != StatusType.Success)
            {
                throw new BusinessRuleException(response.UserMessage);
            }

            return response.ResponseData.Select(x => new SelectListItemDTO
            {
                Id = x.Id,
                Text = x.LongName,
                Title = x.Name
            }).ToList();
        }
    }
}
