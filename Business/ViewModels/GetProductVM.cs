using DAL.Identity;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class GetProductVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Image> Images { get; set; }
        public int ImageCount { get; set; }
        public AppUser AppUser { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public int SquareFt { get; set; }
    }
}
