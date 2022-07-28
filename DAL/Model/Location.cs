using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Location : BaseEntity, IEntity
    {
        [Required]
        public string LocationCity { get; set; }
        [Required]
        public string LocationArea { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
