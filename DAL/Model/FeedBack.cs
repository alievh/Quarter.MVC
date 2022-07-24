using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNetCore.Http;

namespace DAL.Model
{
    public class FeedBack : BaseEntity, IEntity
    {
        public string Content { get; set; }
        public AppUser AppUser { get; set; }
    }
}
