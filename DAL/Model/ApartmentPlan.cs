using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ApartmentPlan : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int TotalArea { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public bool IsPetAllowed { get; set; }
        public int Lounge { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
