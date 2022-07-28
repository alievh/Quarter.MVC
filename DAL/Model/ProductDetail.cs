using DAL.Base;
using DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class ProductDetail : BaseEntity, IEntity
    {
        [Required, Range(1, 2022)]
        public int BuiltYear { get; set; }
        public Product Product { get; set; }
    }
}
