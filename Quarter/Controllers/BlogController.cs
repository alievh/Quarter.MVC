using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;

        public BlogController(IBlogService blogService, IProductService productService, ISubCategoryService subCategoryService)
        {
            _blogService = blogService;
            _productService = productService;
            _subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _blogService.GetAll();
            ViewData["Products"] = await _productService.GetAll();
            ViewData["SubCategories"] = await _subCategoryService.GetAll();

            return View(model: data);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
