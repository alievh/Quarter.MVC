using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class AboutItem : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconLink { get; set; }
        public int AboutAboutId { get; set; }
        public AboutAbout AboutAbout { get; set; }
    }
}
