using Microsoft.AspNetCore.Mvc;
using OBiletCase.WebUI.Filters;
using OBiletCase.WebUI.Models;
using OBiletCase.WebUI.ModelServices;

namespace OBiletCase.WebUI.Controllers
{
    public class BusJourneyController : Controller
    {
        private readonly BusJourneyModelService _modelService;

        public BusJourneyController(BusJourneyModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        [HandleException(Arguments = new object[] { nameof(BusJourneyController) })]
        public async Task<IActionResult> Journey(BusJourneySearchViewModel model)
        {

            var result = await _modelService.GetBusJourneys(model);

            return View();
        }
    }
}
