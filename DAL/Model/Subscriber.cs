using DAL.Entity;
using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Subscriber : IEntity
    {
        public int Id { get; set; }
        public string SubscriberEmail { get; set; }
    }
}
