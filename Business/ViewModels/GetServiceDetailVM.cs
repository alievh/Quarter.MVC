using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class GetServiceDetailVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Service> Services { get; set; }
        public List<Image> Images { get; set; }
    }
}
