using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
