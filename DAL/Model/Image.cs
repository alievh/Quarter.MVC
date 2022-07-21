using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool? IsMain { get; set; }
        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<ApartmentPlan> ApartmentPlans { get; set; }
    }
}
