using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AboutAbout : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Callout { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<AboutItem> AboutItems { get; set; }
    }
}
