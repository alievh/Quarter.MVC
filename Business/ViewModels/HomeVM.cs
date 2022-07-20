using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class HomeVM
    {
        public List<GetSliderVM> Sliders { get; set; }
        public List<GetHomeServiceVM> HomeServices { get; set; }
    }
}
