using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class FeedBack : BaseEntity, IEntity
    {
        [Required]
        public string Content { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
