using Business.Services;
using Business.ViewModels;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceDetailService _serviceDetailService;
        private readonly IServiceService _serviceService;
        private readonly IServiceAboutService _serviceAboutService;

        public ServiceController(IServiceDetailService serviceDetailService, IServiceService serviceService, IServiceAboutService serviceAboutService)
        {
            _serviceDetailService = serviceDetailService;
            _serviceService = serviceService;
            _serviceAboutService = serviceAboutService;
        }

        public async Task<IActionResult> Index()
        {   
            var data = await _serviceService.GetAll();


            List<GetServiceVM> getServiceVMs = new();
            foreach (var service in data)
            {
                List<Image> images = new();
                foreach (var image in service.Images)
                {
                    images.Add(image);
                }
                GetServiceVM getServiceVm = new()
                {
                    Title = service.Title,
                    Description = service.Description,
                    Content = service.ServiceDetail.Content,
                    ServiceDetail = service.ServiceDetail,
                    ForHome = service.ForHome,
                    Images = images
                };
                getServiceVMs.Add(getServiceVm);
            }

            var serviceAbout = await _serviceAboutService.Get(1);

            ServiceVM ServiceVm = new()
            {
                Services = getServiceVMs,
                ServiceAbout = serviceAbout
            };

            return View(model: ServiceVm);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            var data = await _serviceDetailService.Get(id);
            var services = await _serviceService.GetAll();

            List<Image> images = new();
            foreach (var image in data.Service.Images)
            {
                images.Add(image);
            }
            GetServiceDetailVM getServiceDetailVm = new()
            {
                Id = data.Id,
                Content = data.Content,
                Services = services,
                Images = images
            };

            return View(model: getServiceDetailVm);
        }
    }
}
