using Business.Services;
using Business.ViewModels;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IServiceService _serviceService;
        private readonly ILocationService _locationService;
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IFeedBackService _feedBackService;

        public HomeController(ISliderService sliderService,
                              IServiceService serviceService,
                              IProductService productService,
                              ILocationService locationService,
                              IImageService imageService,
                              IFeedBackService feedBackService)
        {
            _serviceService = serviceService;
            _sliderService = sliderService;
            _productService = productService;
            _locationService = locationService;
            _imageService = imageService;
            _feedBackService = feedBackService;
        }

        public async Task<IActionResult> Index()
        {
            List<GetSliderVM> getSliderVms = new();
            foreach (Slider slider in await _sliderService.GetAll())
            {
                GetSliderVM getSliderVm = new()
                {
                    Title = slider.Title,
                    Content = slider.Content,
                    Images = slider.Images
                };
                getSliderVms.Add(getSliderVm);
            }

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

            List<GetLocationVM> getLocationVMs = new();
            foreach (var location in await _locationService.GetAll())
            {
                GetLocationVM getLocationVM = new()
                {
                    Id = location.Id,
                    LocationArea = location.LocationArea,
                    LocationCity = location.LocationCity,
                    Products = location.Products
                };
                getLocationVMs.Add(getLocationVM);
            }

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

            HomeVM homeVm = new()
            {
                Sliders = getSliderVms,
                HomeServices = getHomeServiceVms,
                Products = getProductVMs,
                Locations = getLocationVMs,
                FeedBacks = getFeedBackVMs
            };

            return View(model: homeVm);
        }
    }
}
