using Business.Services;
using Business.ViewModels;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ShopController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _categoryService.GetAll();
            List<GetCategoryVM> getCategoryVMs = new();
            foreach (var category in data)
            {
                GetCategoryVM getCategoryVm = new()
                {
                    CategoryName = category.Name,
                    SubCategories = category.SubCategories,
                };

                getCategoryVMs.Add(getCategoryVm);
            }

            List<GetProductVM> getProductVMs = new();
            foreach (var product in await _productService.GetAll())
            {
                List<Image> images = new();
                foreach (var image in product.Images)
                {
                    images.Add(image);
                }
                GetProductVM getProductVm = new()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    AppUser = product.AppUser,
                    Images = images,
                    ImageCount = images.Count,
                    BedroomCount = product.BedroomCount,
                    BathroomCount = product.BathroomCount,
                    SquareFt = product.SquareFt,
                    SubCategories = product.SubCategories,
                    Location = product.Location
                };
                getProductVMs.Add(getProductVm);
            }

            ShopVM shopVm = new()
            {
                Categories = getCategoryVMs,
                Products = getProductVMs
            };

            return View(model: shopVm);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
