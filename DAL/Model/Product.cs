using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Product : BaseEntity, IEntity
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0, 100000000)]
        public double Price { get; set; }
        [Required, Range(0, 100)]
        public int BedroomCount { get; set; }
        [Required, Range(0, 100)]
        public int BathroomCount { get; set; }
        [Required, Range(0,1000000)]
        public int SquareFt { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ProductDetailId { get; set; }
        public ProductDetail ProductDetail { get; set; }

        [NotMapped]
        public IFormFile MainImage { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFile { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Basket> Baskets { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
