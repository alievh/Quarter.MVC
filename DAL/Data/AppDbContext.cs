using DAL.Identity;
using DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Image> Images { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ApartmentPlan> ApartmentPlans { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<SubscriberMessage> SubscriberMessages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AboutAbout> AboutAbouts { get; set; }
        public DbSet<ServiceAbout> ServiceAbouts { get; set; }
        public DbSet<AboutItem> AboutItems { get; set; }

    }
}
