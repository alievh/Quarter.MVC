using DAL.Base;
using DAL.Entity;

namespace DAL.Model
{
    public class ProductDetail : BaseEntity, IEntity
    {
        public int BuiltYear { get; set; }
        public Product Product { get; set; }
    }
}
