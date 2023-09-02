using Microsoft.AspNetCore.Mvc;
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
            //var a = HttpContext.Request.Headers["User-Agent"].ToString();
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            // Port Bilgisini Al
            var port = HttpContext.Connection.RemotePort;
            //_busLocationService.GetBusLoacations("hatay", DateTime.Now);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}