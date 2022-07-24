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
    public class LocationRepository : ILocationService
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Location> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Locations.Where(n => !n.IsDeleted).Where(n => n.Id == id).Include(n => n.Products).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Location>> GetAll()
        {
            var data = await _context.Locations.Where(n => !n.IsDeleted).Include(n => n.Products).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Location entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Locations.AddAsync(entity);
        }

        public async Task Update(int id, Location entity)
        {
            var data = await Get(id);

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            data.LocationCity = entity.LocationCity;
            data.LocationArea = entity.LocationArea;
            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            _context.Locations.Update(data);
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
