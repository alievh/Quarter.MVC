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
        private readonly IProductService _productService;

        public HomeController(ISliderService sliderService, IServiceService serviceService, IProductService productService)
        {
            _serviceService = serviceService;
            _sliderService = sliderService;
            _productService = productService;
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
                GetProductVM getProductVm = new()
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    AppUser = product.AppUser,
                    Images = images,
                    ImageCount = images.Count,
                    BedroomCount = product.BedroomCount,
                    BathroomCount = product.BathroomCount,
                    SquareFt = product.SquareFt
                };
                getProductVMs.Add(getProductVm);
            }
            


            HomeVM homeVm = new()
            {
                Sliders = getSliderVms,
                HomeServices = getHomeServiceVms,
                Products = getProductVMs
            };

            return View(model: homeVm);
        }
    }
}
