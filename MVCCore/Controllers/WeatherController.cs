using Microsoft.AspNetCore.Mvc;

namespace MVCCore.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
