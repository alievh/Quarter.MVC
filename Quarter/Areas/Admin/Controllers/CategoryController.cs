using Business.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        public CategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> data;

            try
            {
                data = await _categoryService.GetAll();
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
            Category data;
            try
            {
                data = await _categoryService.Get(id);
            }
            catch (ArgumentException ex)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category entity)
        {
            await _categoryService.Create(entity);
            await _categoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await _categoryService.Get(id);

            return View(data);
        }

        public async Task<IActionResult> Update(int id, Category category)
        {
            await _categoryService.Update(id, category);
            await _categoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await _categoryService.Delete(id);
            await _categoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddSubCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubCategory(int? id, SubCategory entity)
        {
            var category = await _categoryService.Get(id);

            foreach (var subCategory in category.SubCategories)
            {
                if(subCategory.Name == entity.Name)
                {
                    return View();
                };
            }

            SubCategory newSubCategory = new()
            {
                Name = entity.Name.Trim(),
                Category = category
            };

            await _subCategoryService.Create(newSubCategory);
            await _subCategoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubCategory(int id)
        {
            var data = await _subCategoryService.Get(id);

            return View(model: data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSubCategory(int id, SubCategory subCategory)
        {
            await _subCategoryService.Update(id, subCategory);
            await _subCategoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSubCategory(int? id)
        {
            await _subCategoryService.Delete(id);
            await _subCategoryService.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
