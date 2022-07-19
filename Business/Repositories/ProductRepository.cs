using Business.Services;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ProductRepository : IProductService
    {
        public ProductRepository()
        {
        }

        public Task<Product> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Create(Product entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
