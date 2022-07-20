using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class GetHomeServiceVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ServiceDetailId { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
