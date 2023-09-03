using Microsoft.AspNetCore.Mvc;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Models;
using System.Diagnostics;

namespace OBiletCase.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusLocationService _busLocationService;

        public HomeController(ILogger<HomeController> logger, IBusLocationService busLocationService)
        {
            _logger = logger;
            _busLocationService = busLocationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchBusLocation(string query)
        {
            HttpContext.Request.Cookies.TryGetValue(Constants.CookieName.Session, out string sessionId);
            HttpContext.Request.Cookies.TryGetValue(Constants.CookieName.Device, out string deviceId);

            var requestModel = new BusLocationRequestModel
            {
                SearchValue = query,
                Date = DateTime.Now,
                DeviceSession = new DeviceSessionModel
                {
                    DeviceId = deviceId,
                    SessionId = sessionId
                },
                Language = "tr-TR"
            };

            var result = await _busLocationService.GetBusLoacations(requestModel);

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}