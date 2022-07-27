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
        private readonly IProductDetailService _productDetailService;
        private readonly IImageService _imageService;

        public ShopController(ICategoryService categoryService, IProductService productService, IImageService imageService, IProductDetailService productDetailService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _imageService = imageService;
            _productDetailService = productDetailService;
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

                Image userImage = null;

                if (product.AppUser.ImageId is not null)
                {
                    userImage = await _imageService.Get(product.AppUser.ImageId);
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
                    Location = product.Location,
                    UserPicture = userImage,
                    ProductDetailId = product.ProductDetailId
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

        public async Task<IActionResult> Detail(int? id)
        {
            var data = await _productDetailService.Get(id);
            var product = await _productService.Get(data.Product.Id);

            List<Image> images = new();
            foreach (var image in data.Product.Images)
            {
                images.Add(image);
            }

            List<Comment> comments = new();
            if(product.Comments is not null)
            {
                comments.AddRange(product.Comments);
            }
            
            Image userImage = await _imageService.Get(product.AppUser.ImageId);

            GetProductDetailVM getProductDetailVm = new()
            {
                Id = data.Id,
                BuiltYear = data.BuiltYear,
                Product = product,
                Images = images,
                AppUser = product.AppUser,
                UserImage = userImage,
                Comments = comments
            };

            return View(model: getProductDetailVm);
        }
    }
}
