using Microsoft.AspNetCore.Mvc;
using OBiletCase.Domain.DataTransferObjects;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Exceptions;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Filters;
using OBiletCase.WebUI.ModelServices;
using System.Globalization;

namespace OBiletCase.WebUI.Controllers
{
    public class BusLocationController : Controller
    {
        private readonly BusLocationModelService _modelService;
        private readonly ILogger<HomeController> _logger;

        public BusLocationController(BusLocationModelService modelService, ILogger<HomeController> logger)
        {
            _modelService = modelService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            List<SelectListItemDTO> result;

            try
            {
                result = await _modelService.GetBusLocationsAsync(query);
            }
            catch(BusinessRuleException bex)
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
