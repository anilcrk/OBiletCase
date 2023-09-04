using Microsoft.AspNetCore.Mvc;
using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Services.Exceptions;
using OBiletCase.WebUI.Filters;
using OBiletCase.WebUI.Models;
using OBiletCase.WebUI.ModelServices;

namespace OBiletCase.WebUI.Controllers
{
    public class BusJourneyController : Controller
    {
        private readonly JourneyModelService _modelService;
        private readonly ILogger<HomeController> _logger;

        public BusJourneyController(JourneyModelService modelService, ILogger<HomeController> logger)
        {
            _modelService = modelService;
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Journey(BusJourneySearchViewModel model)
        {
            var result = await _modelService.GetBusJourneys(model);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> SearchBusLocations(string query)
        {
            List<SelectListItemDTO> result;

            try
            {
                result = await _modelService.GetBusLocationsAsync(query);
            }
            catch (BusinessRuleException bex)
            {
                return Json(new
                {
                    Success = false,
                    Message = bex.Message
                });
            }

            return Json(result);
        }
    }
}
