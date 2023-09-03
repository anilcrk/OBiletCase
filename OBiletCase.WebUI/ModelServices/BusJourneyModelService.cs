using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;
using OBiletCase.WebUI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace OBiletCase.WebUI.ModelServices
{
    public class BusJourneyModelService
    {
        private readonly IBusJourneyService _busJourneyService;
        private readonly IHttpContextAccessor _contextAccessor;

        public BusJourneyModelService(IBusJourneyService busJourneyService, IHttpContextAccessor httpContextAccessor)
        {
            _busJourneyService = busJourneyService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<BusJourneyDetailViewModel> GetBusJourneys(BusJourneySearchViewModel model)
        {
            var requestModel = new BusJourneyRequestModel
            {
                DeviceSession = _contextAccessor.HttpContext.Request.Cookies.GetSessionInfo(),
                DepartureDate = model.DepartureDate,
                DestinationId = model.DestinationId,
                OriginId = model.OriginId
            };

            var result = await _busJourneyService.GetBusJourneys(requestModel);

            return new BusJourneyDetailViewModel
            {
                BusJourneys = result,
                DepartureDateText = model.DepartureDate.ToString("dd MMMM dddd", new CultureInfo("tr-TR")),
                FormHeaderText = $"{model.OriginName} - {model.DestionationName}"
            };
        }
    }
}
