using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class GetLocationVM
    {
        public int Id { get; set; }
        public string LocationCity { get; set; }
        public string LocationArea { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
