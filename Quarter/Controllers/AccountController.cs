using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly ISubscriberService _subscriberService;

        public AccountController(UserManager<AppUser> userManager,
               RoleManager<IdentityRole> roleManager,
               SignInManager<AppUser> signInManager,
               IBasketService basketService,
               IProductService productService,
               ISubscriberService subscriberService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _basketService = basketService;
            _productService = productService;
            _subscriberService = subscriberService;
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

            if (getRegisterVM.Position is not null)
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
            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { token, username = appUser.UserName }, HttpContext.Request.Scheme);

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

        public async Task<IActionResult> ConfirmEmail(string username, string token)
        {
            AppUser appUser = await _userManager.FindByNameAsync(username);

            if (appUser is null)
            {
                return Json("User could not Found");
            }

            var result = await _userManager.ConfirmEmailAsync(appUser, token);

            if (!result.Succeeded)
            {
                return Json("Your token is invalid");
            }

            return RedirectToAction("index", controllerName: "Home");
        }

        public async Task<IActionResult> AddToBasket(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            List<Product> products = new();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var basket = await _basketService.Get(user.BasketId);

                products.AddRange(basket.Products);
                products.Add(await _productService.Get(id));
                basket.Products = products;
                await _basketService.Update(basket.Id, basket);
                await _basketService.SaveChanges();
            }
            else
            {
                var product = await _productService.Get(id);
                Response.Cookies.Append("BasketProducts", product.Id.ToString());

            }

            return ViewComponent("Basket");
        }

        public async Task<IActionResult> DeleteFromBasket(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var user = await _userManager.GetUserAsync(User);

            var basket = await _basketService.Get(user.BasketId);

            List<Product> products = new();

            foreach (var product in basket.Products)
            {
                if (product.Id != id)
                {
                    products.Add(product);
                }
            }

            basket.Products = products;

            await _basketService.Update(basket.Id, basket);
            await _basketService.SaveChanges();

            return ViewComponent("Basket");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(Subscriber subscriber)
        {
            await _subscriberService.Create(subscriber);
            await _subscriberService.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
