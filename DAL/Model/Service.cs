using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Service : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ForHome { get; set; }
        public int ServiceDetailId { get; set; }
        public ServiceDetail ServiceDetail { get; set; }


        [NotMapped]
        public IFormFile ServiceIcon { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFile { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
