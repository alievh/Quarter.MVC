using Business.ViewModels;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using static Utilities.Helpers.Enums;

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

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(GetRegisterVM getRegisterVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json("Ok");
            }

            if (!ModelState.IsValid)
            {
                return View(getRegisterVM);
            }

            AppUser appUser = new();

            Basket basket = new()
            {
                TotalPrice = 0
            };

            Wishlist wishlist = new();

            appUser.Firstname = getRegisterVM.Firstname;
            appUser.Lastname = getRegisterVM.Lastname;
            appUser.Email = getRegisterVM.Email;
            appUser.UserName = getRegisterVM.Username;
            if(getRegisterVM.Position is not null)
            {
                appUser.Position = getRegisterVM.Position;
            }
            appUser.Basket = basket;
            appUser.Wishlist = wishlist;


            var result = await _userManager.CreateAsync(appUser, getRegisterVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                };
                return View(getRegisterVM);
            };

            var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());

            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                };
                return View(getRegisterVM);
            };

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = appUser.Email }, HttpContext.Request.Scheme);

            SendEmail(appUser.Email, confirmationLink);

            return RedirectToAction("Index", controllerName: "Home");

        }

        [HttpGet(nameof(Login))]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(GetLoginVM getLoginVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Json("Ok");
            }

            if (!ModelState.IsValid)
            {
                return View(getLoginVM);
            }

            AppUser appUser = await _userManager.FindByNameAsync(getLoginVM.Username);

            if (appUser is null)
            {
                ModelState.AddModelError("", "Username not found!");
                return View(getLoginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, getLoginVM.Password, getLoginVM.RememberMe, true);

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Please confirm your account!");
                return View(getLoginVM);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your profile has been locked!\nPlease try later!");
                return View(getLoginVM);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username not found!");
                return View(getLoginVM);
            }

            if (await _userManager.IsInRoleAsync(appUser, Roles.Admin.ToString()))
            {
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Admin" });
            }


            return RedirectToAction("Index", controllerName: "Home");
        }

        public async Task<ActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", controllerName: "Home");
        }

        public IActionResult SendEmail(string userEmail, string confirmationLink)
        {
            string from = "aliev.hsyn@gmail.com";
            string to = userEmail;
            string subject = "Confirm you email";
            string body = $"<a href=\"{confirmationLink}\">Click here for confirm your account!</a>";

            MailMessage mailMessage = new(
                from,
                to,
                subject,
                body
            );
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, "vktvykutjpgmwvyz");
            try
            {
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                throw;
            }

            return Json("Ok");
        }

        //public async Task CreateRoles()
        //{
        //    foreach (var item in Enum.GetValues(typeof(Roles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(item.ToString()))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
        //        }
        //    }
        //}
    }
}
