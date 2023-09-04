using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;
using OBiletCase.WebUI.Models;
using System.Globalization;
using OBiletCase.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using OBiletCase.WebUI.Filters;
using OBiletCase.Services.Services;

namespace OBiletCase.WebUI.ModelServices
{
    public class JourneyModelService
    {
        private readonly IJourneyService _journeyService;
        private readonly ILocationService _locationService;
        private readonly IHttpContextAccessor _contextAccessor;

        public JourneyModelService(IJourneyService journeyService, 
                                      ILocationService locationService, 
                                      IHttpContextAccessor httpContextAccessor)
        {
            _journeyService = journeyService;
            _locationService = locationService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<BusJourneyDetailViewModel> GetBusJourneys(BusJourneySearchViewModel model)
        {
            var requestModel = new BusJourneyRequestModel
            {
                DeviceSession = _contextAccessor.HttpContext.GetSessionInfo(),
                DepartureDate = model.DepartureDate,
                DestinationId = model.DestinationId,
                OriginId = model.OriginId
            };

            var result = await _journeyService.GetBusJourneys(requestModel);

            return new BusJourneyDetailViewModel
            {
                BusJourneys = result,
                DepartureDateText = model.DepartureDate.ToString("dd MMMM dddd", new CultureInfo("tr-TR")),
                FormHeaderText = $"{model.OriginName} - {model.DestionationName}"
            };
        }

        public Task<List<SelectListItemDTO>> GetBusLocationsAsync(string query)
        {
            var requestModel = new BusLocationRequestModel
            {
                Query = query,
                DeviceSession = _contextAccessor.HttpContext.GetSessionInfo()
            };

            return _locationService.GetBusLoacations(requestModel);
        }
    }
}
