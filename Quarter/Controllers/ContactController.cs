using Business.Repositories;
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
        private readonly SettingRepository _settingRepository;

        public ContactController(IFeedBackService feedBackService, UserManager<AppUser> userManager, SettingRepository settingRepository)
        {
            _feedBackService = feedBackService;
            _userManager = userManager;
            _settingRepository = settingRepository;
        }

        public IActionResult Index()
        {
            ViewData["settings"] = _settingRepository.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeedBack(FeedBack feedBack)
        {
            ViewData["settings"] = _settingRepository.GetAll();


            if (!ModelState.IsValid)
            {
                return View(feedBack);
            }

            feedBack.AppUser = await _userManager.GetUserAsync(User);

            await _feedBackService.Create(feedBack);
            await _feedBackService.SaveChanges();

            return View(nameof(Index));
        }
    }
}
