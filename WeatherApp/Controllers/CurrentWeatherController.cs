using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    public class CurrentWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
