using Business.Services;
using DAL.Data;
using DAL.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quarter.Components
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly UserManager<AppUser> _userManager;


        public BasketViewComponent(IBasketService basketService, UserManager<AppUser> userManager)
        {
            _basketService = basketService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var basket = await _basketService.Get(user.BasketId);
                double totalPrice = 0;
                if(basket.Products is not null)
                {
                    foreach (var product in basket.Products)
                    {
                        totalPrice += product.Price;
                    }
                }
                basket.TotalPrice = totalPrice;

                return View(basket);
            }
            else
            {
                return View();
            }
        }
    }
}
