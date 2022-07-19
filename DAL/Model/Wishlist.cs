using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using System.Collections.Generic;

namespace DAL.Model
{
    public class Wishlist : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
