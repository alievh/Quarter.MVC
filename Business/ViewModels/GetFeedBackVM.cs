using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class GetFeedBackVM
    {
        public string Content { get; set; }
        public AppUser AppUser { get; set; }
    }
}
