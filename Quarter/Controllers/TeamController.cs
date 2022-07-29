using Business.Services;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class TeamController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IImageService _imageService;

        public TeamController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IImageService imageService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            List<AppUser> adminUsers = new();

            foreach (var user in users)
            {
                if(user.ImageId is not null)
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

            return View(model: adminUsers);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
