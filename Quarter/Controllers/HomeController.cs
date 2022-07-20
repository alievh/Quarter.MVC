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

        public HomeController(ISliderService sliderService, IServiceService serviceService)
        {
            _serviceService = serviceService;
            _sliderService = sliderService;
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
                GetHomeServiceVM getHomeServiceVm = new()
                {
                    Title = service.Title,
                    Description = service.Description,
                    Content = service.ServiceDetail.Content,
                    ServiceDetailId = service.ServiceDetailId,
                    Images = service.Images
                };
                getHomeServiceVms.Add(getHomeServiceVm);
            }


            HomeVM homeVm = new()
            {
                Sliders = getSliderVms,
                HomeServices = getHomeServiceVms
            };

            return View(model: homeVm);
        }
    }
}
