using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.AspNetCore.Hosting;
using Quarter.Helpers.Extensions;
using Business.Services;
using System.Collections.Generic;
using System;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;

        public SliderController(
                                       ISliderService sliderService,
                                       IImageService imageService,
                                       IWebHostEnvironment env)
        {
            _sliderService = sliderService;
            _imageService = imageService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> data;

            try
            {
                data = await _sliderService.GetAll();
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
            Slider data;

            try
            {
                data = await _sliderService.Get(id);
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
        public async Task<IActionResult> Create(Slider entity)
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

            string fileName = await entity.ImageFile.CreateFile(_env);

            Image image = new();
            image.Url = fileName;

            List<Image> images = new();
            images.Add(image);

            List<Slider> sliders = new();
            sliders.Add(entity);


            if (ModelState.IsValid)
            {
                image.Sliders = sliders;
                entity.Images = images;
                await _imageService.Create(image);
                await _sliderService.Create(entity);
                await _sliderService.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _sliderService.Get(id);

            return View(model: data);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, Slider entity)
        {
            await _sliderService.Update(id, entity);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await _sliderService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
