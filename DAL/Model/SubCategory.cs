using DAL.Base;
using DAL.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class SubCategory : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
