using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class BlogCategory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
