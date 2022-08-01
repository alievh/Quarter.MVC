using Business.Repositories;
using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;
        private readonly IBlogService _blogService;
        private readonly SettingRepository _settingRepository;

        public ShopController(ICategoryService categoryService,
                              IProductService productService,
                              IImageService imageService,
                              IProductDetailService productDetailService,
                              ICommentService commentService,
                              UserManager<AppUser> userManager,
                              IBlogService blogService,
                              SettingRepository settingRepository)
        {
            _categoryService = categoryService;
            _productService = productService;
            _imageService = imageService;
            _productDetailService = productDetailService;
            _userManager = userManager;
            _commentService = commentService;
            _blogService = blogService;
            _settingRepository = settingRepository;
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
                Products = getProductVMs,
            };

            return View(model: shopVm);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            ViewData["Products"] = await _productService.GetAll();
            ViewData["Blogs"] = await _blogService.GetAll();
            ViewData["Settings"] = _settingRepository.GetAll();

            var data = await _productDetailService.Get(id);
            var product = await _productService.Get(data.Product.Id);

            List<Image> images = new();
            foreach (var image in data.Product.Images)
            {
                images.Add(image);
            }

            List<Comment> comments = new();
            if (product.Comments is not null)
            {
                foreach (var comment in product.Comments)
                {
                    comment.AppUser = await _userManager.FindByIdAsync(comment.AppUserId);
                    if (comment.AppUser.ImageId is not null)
                    {
                        comment.AppUser.Image = await _imageService.Get(comment.AppUser.ImageId);
                    }
                    comments.Add(comment);
                }
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
                Comments = comments,
                Comment = null,
                LocationId = product.LocationId,
            };

            return View(model: getProductDetailVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(GetProductDetailVM vm, int? id)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            var comment = vm.Comment;
            comment.AppUser = await _userManager.GetUserAsync(User);
            var product = await _productService.Get(id);
            comment.Product = product;

            await _commentService.Create(comment);
            await _commentService.SaveChanges();

            return RedirectToAction(nameof(Detail), vm);
        }

        public async Task<IActionResult> Filter(int? id)
        {
            var data = await _productService.Filter(id);

            return PartialView("_ShopPartial", model: data);
        }

    }
}
