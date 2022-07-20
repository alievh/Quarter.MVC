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
    public class ServiceRepository : IServiceService
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Service> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Services.Where(n => !n.IsDeleted).Where(n => n.Id == id).Include(n => n.Images).Include(n => n.ServiceDetail).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Service>> GetAll()
        {
            var data = await _context.Services.Where(n => !n.IsDeleted).Include(n => n.Images).Include(n => n.ServiceDetail).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Service entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Services.AddAsync(entity);
        }

        public async Task Update(int id, Service entity)
        {
            var data = await Get(id);

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            data.Title = entity.Title;
            data.Description = entity.Description;
            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            _context.Services.Update(data);
        }

        public async Task Delete(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await Get(id);

            data.IsDeleted = true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
