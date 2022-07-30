using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class BlogDetail : BaseEntity, IEntity
    {
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}
