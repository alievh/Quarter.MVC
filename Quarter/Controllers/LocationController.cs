using Microsoft.AspNetCore.Mvc;

namespace Quarter.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
