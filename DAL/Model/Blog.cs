using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Blog : BaseEntity, IEntity
    {
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
