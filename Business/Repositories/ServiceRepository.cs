using Business.Services;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ServiceRepository : IServiceService
    {
        public Task<Service> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Create(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Service entity)
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
