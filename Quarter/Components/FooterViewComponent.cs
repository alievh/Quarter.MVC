using Business.Repositories;
using Business.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISubscriberService _subscriberService;
        private readonly SettingRepository _settingRepository;

        public FooterViewComponent(ISubscriberService subscriberService, SettingRepository settingRepository)
        {
            _subscriberService = subscriberService;
            _settingRepository = settingRepository;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            Subscriber subscriber = new();
            ViewData["settings"] = _settingRepository.GetAll();

            return Task.FromResult<IViewComponentResult>(View(model: subscriber));
        }
    }
}
