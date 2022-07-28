using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ApartmentPlan : BaseEntity, IEntity
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int TotalArea { get; set; }
        public int BedroomCount { get; set; }
        public int BathroomCount { get; set; }
        public bool IsPetAllowed { get; set; }
        public int Lounge { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
