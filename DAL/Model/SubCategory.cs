using DAL.Base;
using DAL.Entity;

namespace DAL.Model
{
    public class SubCategory : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
