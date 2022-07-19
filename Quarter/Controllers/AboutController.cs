using Microsoft.AspNetCore.Mvc;

namespace Quarter.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
