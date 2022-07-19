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
    public class Comment : BaseEntity, IEntity
    {
        public string Content { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
