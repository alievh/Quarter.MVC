using DAL.Identity;
using DAL.Model;
using System.Collections.Generic;

namespace Business.ViewModels
{
    public class GetProductDetailVM
    {
        public int Id { get; set; }
        public int BuiltYear { get; set; }
        public Product Product { get; set; }
        public List<Image> Images { get; set; }
        public AppUser AppUser { get; set; }
        public Image UserImage { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
