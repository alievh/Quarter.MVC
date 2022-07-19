using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Service : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
