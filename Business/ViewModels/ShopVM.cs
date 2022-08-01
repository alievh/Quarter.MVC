using System.Collections.Generic;

namespace Business.ViewModels
{
    public class ShopVM
    {
        public List<GetProductVM> Products { get; set; }
        public List<GetCategoryVM> Categories { get; set; }
        public List<GetBlogVM> Blogs { get; set; }
    }
}
