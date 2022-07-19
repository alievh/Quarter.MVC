using Microsoft.AspNetCore.Mvc;

namespace Quarter.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
