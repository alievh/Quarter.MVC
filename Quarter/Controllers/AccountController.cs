using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet(nameof(Register))]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost(nameof(Register))]
        //public async Task<IActionResult> Register(GetRegisterVM getRegisterVM)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return Json("Ok");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(getRegisterVM);
        //    }

        //    AppUser appUser = new AppUser();

        //    appUser.FirstName = getRegisterVM.Firstname;
        //    appUser.LastName = getRegisterVM.Lastname;
        //    appUser.Email = getRegisterVM.Email;
        //    appUser.UserName = getRegisterVM.Username;

        //    var result = await _userManager.CreateAsync(appUser, getRegisterVM.Password);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        };
        //        return View(getRegisterVM);
        //    };

        //    var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());

        //    if (!roleResult.Succeeded)
        //    {
        //        foreach (var item in roleResult.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        };
        //        return View(getRegisterVM);
        //    };

        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
        //    var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = appUser.Email }, HttpContext.Request.Scheme);

        //    SendEmail(appUser.Email, confirmationLink);

        //    return RedirectToAction("Index", controllerName: "Home");

        //}

        [HttpGet(nameof(Login))]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", controllerName: "Home");
        }
    }
}
