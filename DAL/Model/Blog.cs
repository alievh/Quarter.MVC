using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Blog : BaseEntity, IEntity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BlogDetailId { get; set; }
        public BlogDetail BlogDetail { get; set; }

        [NotMapped]
        public IFormFile MainFile { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFile{ get; set; }

        public List<BlogCategory> BlogCategories { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
