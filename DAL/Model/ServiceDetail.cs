using DAL.Base;
using DAL.Entity;

namespace DAL.Model
{
    public class ServiceDetail : BaseEntity, IEntity
    {
        public string Content { get; set; }
        public Service Service { get; set; }
    }
}
