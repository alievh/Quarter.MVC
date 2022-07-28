using Business.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISubscriberService _subscriberService;

        public FooterViewComponent(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            Subscriber subscriber = new();

            return Task.FromResult<IViewComponentResult>(View(model: subscriber));
        }
    }
}
