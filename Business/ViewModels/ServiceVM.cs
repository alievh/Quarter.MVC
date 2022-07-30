using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class ServiceVM
    {
        public List<GetServiceVM> Services { get; set; }
        public ServiceAbout ServiceAbout { get; set; }
    }
}
