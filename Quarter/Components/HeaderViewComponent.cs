using Business.Repositories;
using Business.Services;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly SettingRepository _settingRepository;

        public HeaderViewComponent(SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> values = new();
            values.Add(_settingRepository.Get("headerLogo"));

            return View(await Task.FromResult(values));
        }
    }
}
