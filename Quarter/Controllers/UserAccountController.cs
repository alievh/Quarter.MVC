using Business.Services;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;


        public UserAccountController(UserManager<AppUser> userManager, IImageService imageService, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _imageService = imageService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            AppUser applicationUser = await _userManager.GetUserAsync(User);

            if (applicationUser.ImageId is not null)
            {
                applicationUser.Image = await _imageService.Get(applicationUser.ImageId);
            }

            return View(applicationUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProfilePicture(AppUser appUser)
        {
            AppUser applicationUser = await _userManager.GetUserAsync(User);
            string fileName = await appUser.ProfileImage.CreateFile(_env);

            Image image = new();
            image.Url = fileName;
            image.IsMain = true;
            image.AppUser = applicationUser;

            if (appUser.ImageId is not null)
            {
                await _imageService.Update((int)appUser.ImageId, image);
                await _imageService.SaveChanges();

            }else
            {
                await _imageService.Create(image);
                await _imageService.SaveChanges();
            }

            applicationUser.Image = image;
            
            return View(nameof(Index), applicationUser);

        }
    }
}
