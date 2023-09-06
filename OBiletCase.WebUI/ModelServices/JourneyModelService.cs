using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;
using OBiletCase.WebUI.Models;
using System.Globalization;
using OBiletCase.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using OBiletCase.Services.Services;

namespace OBiletCase.WebUI.ModelServices
{
    /// <summary>
    /// Responsible for managing operations related to the bus journey.
    /// Acts as a bridge between the controller and the services.
    /// </summary>
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

        /// <summary>
        /// Fetches bus journey details based on search criteria and prepares the view model.
        /// </summary>
        /// <param name="model">The search criteria for bus journeys.</param>
        /// <returns>A detailed view model containing bus journeys.</returns>
        public async Task<BusJourneyDetailViewModel> GetBusJourneys(BusJourneySearchViewModel model)
        {
            _contextAccessor.HttpContext.SetObjectToSession(Constants.SessionName.BusState, model);

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

        /// <summary>
        /// Fetches bus locations based on a search query.
        /// </summary>
        /// <param name="query">The search query for bus locations.</param>
        /// <returns>A list of selectable bus locations.</returns>
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
