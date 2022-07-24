using Business.Services;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ContactController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFeedBackService _feedBackService;

        public ContactController(IFeedBackService feedBackService, UserManager<AppUser> userManager)
        {
            _feedBackService = feedBackService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeedBack(FeedBack feedBack)
        {
            feedBack.AppUser = await _userManager.GetUserAsync(User);

            await _feedBackService.Create(feedBack);
            await _feedBackService.SaveChanges();

            return View(nameof(Index));
        }
    }
}
