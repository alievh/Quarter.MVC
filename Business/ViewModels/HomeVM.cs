using System.Collections.Generic;

namespace Business.ViewModels
{
    public class HomeVM
    {
        public List<GetSliderVM> Sliders { get; set; }
        public List<GetHomeServiceVM> HomeServices { get; set; }
        public List<GetProductVM> Products { get; set; }
        public List<GetLocationVM> Locations { get; set; }
        public List<GetFeedBackVM> FeedBacks { get; set; }
    }
}
