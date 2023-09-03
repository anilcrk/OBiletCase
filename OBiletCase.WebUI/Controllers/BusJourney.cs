using Microsoft.AspNetCore.Mvc;
using OBiletCase.WebUI.Models;

namespace OBiletCase.WebUI.Controllers
{
    public class BusJourney : Controller
    {
        public IActionResult Index(BusJourneySearchViewModel model)
        {
            return View();
        }
    }
}
