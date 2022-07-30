using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class DashboardVM
    {
        public List<Comment> Comments { get; set; }
        public List<GetFeedBackVM> FeedBacks { get; set; }
    }
}
