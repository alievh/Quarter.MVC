using Business.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Components
{
    public class HeaderViewComponent : ViewComponent
    {
       
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
