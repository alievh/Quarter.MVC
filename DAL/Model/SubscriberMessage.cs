using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class SubscriberMessage : IEntity
    {
        public int Id { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
