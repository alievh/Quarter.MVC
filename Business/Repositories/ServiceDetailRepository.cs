
using Business.Services;
using DAL.Data;
using DAL.Model;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ServiceDetailRepository : IServiceDetailService
    {
        private readonly AppDbContext _context;

        public ServiceDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceDetail> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ServiceDetails.Where(n => !n.IsDeleted).Where(n => n.Id == id).Include(n => n.Service).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<ServiceDetail>> GetAll()
        {
            var data = await _context.ServiceDetails.Where(n => !n.IsDeleted).Include(n => n.Service).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(ServiceDetail entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.ServiceDetails.AddAsync(entity);
        }

        public async Task Update(int id, ServiceDetail entity)
        {
            var data = await Get(id);

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            data.Content = entity.Content;
            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            _context.ServiceDetails.Update(data);
        }

        public async Task Delete(int? id)
        {
            var data = await Get(id);

            data.IsDeleted = true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
