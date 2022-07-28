using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Slider : BaseEntity, IEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


        public ICollection<Image> Images { get; set; }
    }
}
