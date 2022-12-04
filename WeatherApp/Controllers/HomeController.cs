﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Logic;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WeatherResult(string zipCode)
        {
            var weatherApi = new WeatherApi();
            var weatherModel = weatherApi.GetForecast(zipCode);

            return View(weatherModel);
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