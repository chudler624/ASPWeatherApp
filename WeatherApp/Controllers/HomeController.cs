using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        public IActionResult GetWeatherForcast(string zipCode)
        {
            //get 5 day forcast



            var fiveDayWeatherApi = new WeatherApi();
            var result = fiveDayWeatherApi.GetFiveDayForcast(zipCode);

            return View("CurrentWeather", result);
        }

        //public IActionResult FiveDayWeather()
        //{
        //    var fiveDayWeatherApi = new FiveDayWeatherApi();

        //    return View();
        //}
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