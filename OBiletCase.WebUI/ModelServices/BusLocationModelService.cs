using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;
using System.Globalization;

namespace OBiletCase.WebUI.ModelServices
{
    public class BusLocationModelService
    {
        private readonly IBusLocationService _busLocationService;
        private readonly IHttpContextAccessor _contextAccessor;

        public BusLocationModelService(IBusLocationService busLocationService, IHttpContextAccessor contextAccessor)
        {
            _busLocationService = busLocationService;
            _contextAccessor = contextAccessor;
        }

        public Task<List<SelectListItemDTO>> GetBusLocationsAsync(string query)
        {
            var requestModel = new BusLocationRequestModel
            {
                Query = query,
                DeviceSession = _contextAccessor.HttpContext.Request.Cookies.GetSessionInfo(),
                Language = "tr-TR"
            };

            return _busLocationService.GetBusLoacations(requestModel);
        }
    }
}
