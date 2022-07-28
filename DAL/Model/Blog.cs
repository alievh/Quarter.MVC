using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Blog : BaseEntity, IEntity
    {
        [Required]
        public string Title { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string AppUserId { get; set; }
        public AppUser MyProperty { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
