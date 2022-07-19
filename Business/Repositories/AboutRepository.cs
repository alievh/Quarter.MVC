using Business.Services;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class AboutRepository : IAboutService
    {
        public Task<About> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<About>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Create(About entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, About entity)
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
