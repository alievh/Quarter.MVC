using Microsoft.AspNetCore.Mvc;

namespace Quarter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
