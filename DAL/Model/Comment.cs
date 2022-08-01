using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Comment : BaseEntity, IEntity
    {
        [Required, MaxLength(255)]
        public string Content { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
