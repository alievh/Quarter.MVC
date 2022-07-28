using Business.Services;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public WishlistController(IWishlistService wishlistService, UserManager<AppUser> userManager, IProductService productService)
        {
            _wishlistService = wishlistService;
            _userManager = userManager;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userWishlist = await _wishlistService.Get(user.WishlistId);

            return View(model: userWishlist);
        }


        public async Task<IActionResult> AddToWishlist(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            List<Product> products = new();
            Wishlist wishlist = new();
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                wishlist = await _wishlistService.Get(user.BasketId);

                products.AddRange(wishlist.Products);
                products.Add(await _productService.Get(id));
                wishlist.Products = products;
                await _wishlistService.Update(wishlist.Id, wishlist);
                await _wishlistService.SaveChanges();
            }

            return PartialView("_WishlistPartial", model: wishlist);
        }


        public async Task<IActionResult> DeleteFromWishlist(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var user = await _userManager.GetUserAsync(User);

            var wishlist = await _wishlistService.Get(user.WishlistId);

            List<Product> products = new();

            foreach (var product in wishlist.Products)
            {
                if (product.Id != id)
                {
                    products.Add(product);
                }
            }

            wishlist.Products = products;

            await _wishlistService.Update(wishlist.Id, wishlist);
            await _wishlistService.SaveChanges();

            return PartialView("_WishlistPartial", model: wishlist);
        }

    }
}
