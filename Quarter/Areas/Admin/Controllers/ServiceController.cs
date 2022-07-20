﻿using Business.Services;
using DAL.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IImageService _imageService;
        private readonly IServiceDetailService _detailService;
        private readonly IWebHostEnvironment _env;

        public ServiceController(IServiceService serviceService,
                                IImageService imageService,
                                IServiceDetailService detailService,
                                IWebHostEnvironment env)
        {
            _serviceService = serviceService;
            _imageService = imageService;
            _detailService = detailService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Service> data;

            try
            {
                data = await _serviceService.GetAll();
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            return View(model: data);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            Service data;

            try
            {
                data = await _serviceService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            return View(model: data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Service entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            if (entity.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(entity);
            }

            List<Image> images = new();

            foreach (var imageFile in entity.ImageFile)
            {
                string fileName = await imageFile.CreateFile(_env);

                Image image = new();
                image.Url = fileName;
                images.Add(image);
            }

            Image iconImage = new();
            string iconFileName = await entity.ServiceIcon.CreateFile(_env);
            iconImage.Url = iconFileName;
            images.Add(iconImage);

            entity.Images = images;

            ServiceDetail serviceDetail = new()
            {
                Content = entity.ServiceDetail.Content,
                CreateDate = DateTime.UtcNow.AddHours(4),
            };

            entity.ServiceDetail = serviceDetail;
            entity.ServiceDetailId = serviceDetail.Id;

            List<Service> services = new();
            services.Add(entity);


            await _serviceService.Create(entity);
            await _serviceService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _serviceService.Get(id);

            return View(model: data);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, Service entity)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(entity);
            //}

            //if (entity.ImageFile is null)
            //{
            //    ModelState.AddModelError("ImageFile", "Image can not be empty");
            //    return View(entity);
            //}

            foreach (var imageFile in entity.ImageFile)
            {

                if (imageFile is not null)
                {
                    string fileName = await imageFile.CreateFile(_env);

                    Image image = new();
                    image.Url = fileName;

                    List<Service> services = new();
                    services.Add(entity);
                    image.Services = services;
                    var data = await _serviceService.Get(id);
                    await _imageService.Update(data.Images.FirstOrDefault().Id, image);
                }



                

                await _serviceService.Update(id, entity);
                await _imageService.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await _serviceService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
