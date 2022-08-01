using Business.Services;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Admin,SuperAdmin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(IBlogService blogService, 
                              IBlogCategoryService blogCategoryService,
                              IImageService imageService,
                              IWebHostEnvironment env,
                              UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
            _imageService = imageService;
            _env = env;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAll();

            return View(model: blogs);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            Blog data;

            try
            {
                data = await _blogService.Get(id);
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
        public async Task<IActionResult> Create()
        {
            ViewData["BlogCategory"] = await _blogCategoryService.GetAll();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog entity)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(entity);
            //}

            ViewData["BlogCategory"] = await _blogCategoryService.GetAll();


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
            string mainFileName = await entity.MainFile.CreateFile(_env);
            mainImage.Url = mainFileName;
            mainImage.IsMain = true;
            images.Add(mainImage);

            entity.Images = images;

            BlogDetail blogDetail = new()
            {
                Content = entity.BlogDetail.Content,
            };

            entity.BlogDetail = blogDetail;
            entity.BlogDetailId = blogDetail.Id;

            List<BlogCategory> blogCategories = new();
            foreach (var blogCategory in entity.BlogCategories)
            {
                if (blogCategory.IsSelected == true)
                {
                    BlogCategory blogCategorySub = new();
                    blogCategorySub = await _blogCategoryService.Get(blogCategory.Id);
                    blogCategories.Add(blogCategorySub);
                }
            }

            entity.BlogCategories = blogCategories;

            AppUser applicationUser = await _userManager.GetUserAsync(User);

            entity.AppUser = applicationUser;

            await _blogService.Create(entity);
            await _blogService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _blogService.Get(id);

            return View(model: data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Blog entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            List<Image> currentImages = new();
            var data = await _blogService.Get(id);

            if (entity.ImageFile is not null)
            {
                for (int i = 0; i < data.Images.Where(n => n.IsMain == false).ToList().Count; i++)
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
            }
            else
            {
                for (int i = 0; i < data.Images.Where(n => n.IsMain == false).ToList().Count; i++)
                {
                    currentImages.Add(data.Images.Where(n => n.IsMain == false).ToList()[i]);
                }
            }

            if (entity.MainFile is not null)
            {
                string fileName = await entity.MainFile.CreateFile(_env);

                Image image = new();
                image.Url = fileName;
                image.IsMain = true;
                currentImages.Add(image);

                await _imageService.Delete(data.Images.Where(n => n.IsMain == true).FirstOrDefault().Id);
            }
            else
            {
                currentImages.Add(data.Images.Where(n => n.IsMain == true).FirstOrDefault());
            }

            entity.Images = currentImages;  

            await _blogService.Update(id, entity);
            await _blogService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await _blogService.Delete(id);

            return View(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(BlogCategory blogCategory)
        {
            await _blogCategoryService.Create(blogCategory);
            await _blogCategoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
