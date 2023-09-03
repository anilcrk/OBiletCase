using Microsoft.AspNetCore.Mvc;

namespace OBiletCase.WebUI.Controllers
{
    public class BusJourneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
