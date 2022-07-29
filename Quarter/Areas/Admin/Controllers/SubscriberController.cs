using Business.Services;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "SuperAdmin")]
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService _subscriberService;
        private readonly UserManager<AppUser> _userManager;

        public SubscriberController(ISubscriberService subscriberService, UserManager<AppUser> userManager)
        {
            _subscriberService = subscriberService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var subscribers = await _subscriberService.GetAll();
            return View(model: subscribers);
        }

        public IActionResult SendEmail()
        {
            SubscriberMessage message = new();

            return View(model: message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(SubscriberMessage subscriberMessage)
        {
            if (!ModelState.IsValid)
            {
                return View(subscriberMessage);
            }

            var subscribers = await _subscriberService.GetAll();

            var user = await _userManager.GetUserAsync(User);
            string from = user.Email;
            string subject = $"Quarter Features";
            string body = $"{subscriberMessage.Content}";

            foreach (var subscriber in subscribers)
            {
                string to = subscriber.SubscriberEmail;
                MailMessage mailMessage = new(
                    from,
                    to,
                    subject,
                    body
                );
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, "vktvykutjpgmwvyz");
                try
                {
                    client.Send(mailMessage);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
