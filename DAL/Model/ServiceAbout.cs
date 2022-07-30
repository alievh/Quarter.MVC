using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ServiceAbout : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
