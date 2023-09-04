using OBiletCase.ApiClientAdapter.Interfaces;
using OBiletCase.ApiClientAdapter.Models.RequestModels;
using OBiletCase.Domain.DataTransferObjects;
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
    public class JourneyService : IJourneyService
    {
        private readonly IOBiletApiClient _apiClient;

        public JourneyService(IOBiletApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<BusJourneyDTO>> GetBusJourneys(BusJourneyRequestModel request)
        {
            var response = await _apiClient.GetBusJourneys(request);

            if(response.Status != ApiClientAdapter.Enums.StatusType.Success)
            {
                throw new BusinessRuleException(response.UserMessage);
            }

            var result = response.ResponseData.Select(x => new BusJourneyDTO
            {
                InternetPrice = x.Journey.InternetPrice,
                ArrivalDate = x.Journey.Arrival,
                Currency = x.Journey.Currency,
                DepartureDate = x.Journey.Departure,
                DestinationLocation = x.Journey.Destination,
                OriginLocation = x.Journey.Origin
            }).ToList();

            return result;
        }
    }
}
