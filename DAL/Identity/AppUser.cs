﻿using DAL.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL.Identity
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }

        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
