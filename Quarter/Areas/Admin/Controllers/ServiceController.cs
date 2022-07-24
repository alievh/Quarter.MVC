using Business.Services;
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
                image.IsMain = false;
                images.Add(image);
            }

            Image mainImage = new();
            string mainFileName = await entity.MainImage.CreateFile(_env);
            mainImage.Url = mainFileName;
            mainImage.IsMain = true;
            images.Add(mainImage);

            Image iconImage = new();
            string iconFileName = await entity.ServiceIcon.CreateFile(_env);
            iconImage.Url = iconFileName;
            iconImage.IsMain = false;
            images.Add(iconImage);


            entity.Images = images;

            ServiceDetail serviceDetail = new()
            {
                Content = entity.ServiceDetail.Content,
                CreateDate = DateTime.UtcNow.AddHours(4),
            };

            entity.ServiceDetail = serviceDetail;
            entity.ServiceDetailId = serviceDetail.Id;

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
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            List<Image> currentImages = new();
            var data = await _serviceService.Get(id);

            if (entity.ImageFile is not null)
            {
                for (int i = 0; i < data.Images.Where(n => n.IsMain == false).ToList().Count - 1; i++)
                {
                    currentImages.Add(data.Images.Where(n => n.IsMain == false).ToList()[i]);
                }

                foreach (var imageFile in entity.ImageFile)
                {
                    string fileName = await imageFile.CreateFile(_env);

                    Image image = new();
                    image.Url = fileName;
                    image.IsMain = false;
                    currentImages.Add(image);
                }

                var images = data.Images;
                currentImages.AddRange(images);
            }else
            {
                for (int i = 0; i < data.Images.Where(n => n.IsMain == false).ToList().Count - 1; i++)
                {
                    currentImages.Add(data.Images.Where(n => n.IsMain == false).ToList()[i]);
                }
            }

            if (entity.MainImage is not null)
            {
                string fileName = await entity.ServiceIcon.CreateFile(_env);

                Image image = new();
                image.Url = fileName;
                image.IsMain = true;
                currentImages.Add(image);

                await _imageService.Delete(data.Images.Where(n => n.IsMain == true).FirstOrDefault().Id);
            }else
            {
                currentImages.Add(data.Images.Where(n => n.IsMain == true).FirstOrDefault());
            }

            if (entity.ServiceIcon is not null)
            {
                string fileName = await entity.ServiceIcon.CreateFile(_env);

                Image image = new();
                image.Url = fileName;
                image.IsMain = false;
                currentImages.Add(image);

                await _imageService.Delete(data.Images.Where(n => n.IsMain == false).ToList()[^1].Id);
            }
            else
            {
                currentImages.Add(data.Images.Where(n => n.IsMain == false).ToList()[^1]);
            }

            entity.Images = currentImages;

            await _serviceService.Update(id, entity);
            await _serviceService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            await _imageService.Delete(id);
            await _imageService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _serviceService.Delete(id);

            return RedirectToAction(nameof(Update));
        }
    }
}
