using Business.Services;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Components
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;


        public BlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _blogService.GetAll();

            return View(data);
        }
    }
}
