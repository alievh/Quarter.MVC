using Microsoft.AspNetCore.Mvc;

namespace Quarter.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
