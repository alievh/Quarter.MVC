using Business.Base;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductService : IBaseService<Product>
    {
        Task<List<Product>> Filter(int? id);
    }
}
