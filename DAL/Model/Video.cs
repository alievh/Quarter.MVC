using DAL.Entity;
using System.Collections.Generic;

namespace DAL.Model
{
    public class Video : IEntity
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public ICollection<About> Abouts { get; set; }
    }
}
