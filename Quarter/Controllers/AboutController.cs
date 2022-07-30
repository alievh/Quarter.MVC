using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutAboutService _aboutAboutService;
        private readonly IServiceService _serviceService;
        private readonly IImageService _imageService;
        private readonly IFeedBackService _feedBackService;
        private readonly UserManager<AppUser> _userManager;

        public AboutController(IAboutAboutService aboutAboutService, 
                               IServiceService serviceService, 
                               IImageService imageService, 
                               IFeedBackService feedBackService,
                               UserManager<AppUser> userManager)
        {
            _aboutAboutService = aboutAboutService;
            _serviceService = serviceService;
            _userManager = userManager;
            _imageService = imageService;
            _feedBackService = feedBackService;
        }

        public async Task<IActionResult> Index()
        {
            var aboutAbout = await _aboutAboutService.Get(1);

            List<GetHomeServiceVM> getHomeServiceVms = new();
            foreach (Service service in await _serviceService.GetAll())
            {
                List<Image> images = new();
                foreach (var image in service.Images)
                {
                    images.Add(image);
                }
                GetHomeServiceVM getHomeServiceVm = new()
                {
                    Title = service.Title,
                    Description = service.Description,
                    Content = service.ServiceDetail.Content,
                    ServiceDetailId = service.ServiceDetailId,
                    ForHome = service.ForHome,
                    Images = images
                };
                getHomeServiceVms.Add(getHomeServiceVm);
            }

            var users = await _userManager.Users.ToListAsync();

            List<AppUser> adminUsers = new();

            foreach (var user in users)
            {
                if (user.ImageId is not null)
                {
                    user.Image = await _imageService.Get(user.ImageId);
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    if (userRole.ToString() == "Admin")
                    {
                        adminUsers.Add(user);
                    }
                }
            }

            adminUsers.RemoveRange(2, adminUsers.Count - 3);

            List<GetFeedBackVM> getFeedBackVMs = new();
            foreach (var feedback in await _feedBackService.GetAll())
            {
                Image userImage = null;

                if (feedback.AppUser.ImageId is not null)
                {
                    userImage = await _imageService.Get(feedback.AppUser.ImageId);
                }

                GetFeedBackVM getFeedBackVm = new()
                {
                    Content = feedback.Content,
                    AppUser = feedback.AppUser,
                    UserImage = userImage
                };

                getFeedBackVMs.Add(getFeedBackVm);
            }

            AboutVM aboutVm = new()
            {
                AboutAbout = aboutAbout,
                HomeServices = getHomeServiceVms,
                Users = adminUsers,
                FeedBacks = getFeedBackVMs
            };



            return View(model: aboutVm);
        }
    }
}
