using Microsoft.AspNetCore.Mvc;

namespace Quarter.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
