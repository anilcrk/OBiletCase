﻿using Microsoft.AspNetCore.Mvc;
using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Models;
using System.Diagnostics;

namespace OBiletCase.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJourneyService _busLocationService;

        public HomeController(ILogger<HomeController> logger, IJourneyService busLocationService)
        {
            _logger = logger;
            _busLocationService = busLocationService;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}