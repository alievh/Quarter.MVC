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
    public class Basket : BaseEntity, IEntity
    {
        public double TotalPrice { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
