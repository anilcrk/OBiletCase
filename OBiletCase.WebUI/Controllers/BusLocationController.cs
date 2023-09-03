using Microsoft.AspNetCore.Mvc;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.ModelServices;
using System.Globalization;

namespace OBiletCase.WebUI.Controllers
{
    public class BusLocationController : Controller
    {
        private readonly BusLocationModelService _modelService;

        public BusLocationController(IBusJourneyService busLocationService, BusLocationModelService modelService)
        {
            _modelService = modelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            var result = await _modelService.GetBusLocationsAsync(query);

            return Json(result);
        }
    }
}
