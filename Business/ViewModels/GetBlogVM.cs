using DAL.Identity;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class GetBlogVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public ICollection<Image> Images { get; set; }
        public AppUser AppUser { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public BlogDetail BlogDetail { get; set; }
    }
}
