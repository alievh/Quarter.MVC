using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class BlogCategory : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
