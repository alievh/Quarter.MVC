using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Admin,SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly IFeedBackService _feedBackService;
        private readonly IImageService _imageService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IFeedBackService feedBackService, IImageService imageService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _feedBackService = feedBackService;
            _imageService = imageService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedBackService.GetAll();
            List<GetFeedBackVM> getFeedBackVms = new();
            foreach (var feedback in feedbacks)
            {
                var userImage = await _imageService.Get(feedback.AppUser.ImageId);
                GetFeedBackVM getFeedBackVm = new()
                {
                    Content = feedback.Content,
                    AppUser = feedback.AppUser,
                    UserImage = userImage
                };
                getFeedBackVms.Add(getFeedBackVm);
            }

            List<Comment> comments = await _commentService.GetAll();

            DashboardVM dashboardVm = new()
            {
                FeedBacks = getFeedBackVms,
                Comments = comments
            };

            return View(model: dashboardVm);
        }

        public async Task<IActionResult> DeleteComment(int? id)
        {
            var comment = await _commentService.Get(id);

            comment.IsDeleted = true;
            await _commentService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
