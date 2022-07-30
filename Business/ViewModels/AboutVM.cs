using DAL.Identity;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class AboutVM
    {
        public AboutAbout AboutAbout { get; set; }
        public List<GetHomeServiceVM> HomeServices { get; set; }
        public List<AppUser> Users { get; set; }
        public List<GetFeedBackVM> FeedBacks { get; set; }

    }
}
