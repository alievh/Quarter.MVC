using Business.Services;
using DAL.Data;
using DAL.Model;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ServiceAboutRepository : IServiceAboutService
    {
        private readonly AppDbContext _context;

        public ServiceAboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceAbout> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ServiceAbouts.Where(n => n.Id == id).Include(n=>n.Image).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<ServiceAbout>> GetAll()
        {
            var data = await _context.ServiceAbouts.Include(n => n.Image).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public Task Create(ServiceAbout entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, ServiceAbout entity)
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
