using Microsoft.AspNetCore.Mvc;
using OBiletCase.WebUI.Models;
using OBiletCase.WebUI.ModelServices;

namespace OBiletCase.WebUI.Controllers
{
    public class BusJourneyController : Controller
    {
        private readonly BusJourneyModelService _modelService;
        private readonly ILogger<HomeController> _logger;

        public BusJourneyController(BusJourneyModelService modelService, ILogger<HomeController> logger)
        {
            _modelService = modelService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Journey(BusJourneySearchViewModel model)
        {
            var result = await _modelService.GetBusJourneys(model);

            return View(result);
        }
    }
}
