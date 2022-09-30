using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    public class FiveDayWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
