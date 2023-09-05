using Microsoft.AspNetCore.Mvc;
using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Services.Exceptions;
using OBiletCase.WebUI.Filters;
using OBiletCase.WebUI.Models;
using OBiletCase.WebUI.ModelServices;

namespace OBiletCase.WebUI.Controllers
{
    [HandleException(Arguments = new object[] { nameof(BusJourneyController) })]
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
            var model = new BusJourneySearchViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("seferler")]
        public async Task<IActionResult> Journey(BusJourneySearchViewModel model)
        {
            // TODO: PRG pattern can be applied.
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), model);
            }

            var result = await _modelService.GetBusJourneys(model);

            return View(result);
        }

        /// <summary>
        /// Search and return bus locations.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SearchBusLocations(string query)
        {
            var result = await _modelService.GetBusLocationsAsync(query);

            return Ok(result);
        }
    }
}
