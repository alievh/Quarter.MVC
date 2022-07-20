using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Quarter.Controllers
{
    public class ServiceController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if(id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return View();
        }
    }
}
