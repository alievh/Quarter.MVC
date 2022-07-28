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
    public class ProductRepository : IProductService
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Products.Where(n => !n.IsDeleted)
                                              .Where(n => n.Id == id)
                                              .Include(n => n.Images)
                                              .Include(n => n.AppUser)
                                              .ThenInclude(n=>n.Image)
                                              .Include(n => n.Comments)
                                              .Include(n => n.Location)
                                              .Include(n => n.SubCategories)
                                              .AsSplitQuery()
                                              .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Product>> GetAll()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                             .Include(n => n.Images)
                                             .Include(n => n.AppUser)
                                             .ThenInclude(n => n.Image)
                                             .Include(n => n.Comments)
                                             .Include(n => n.Location)
                                             .Include(n => n.SubCategories)
                                             .AsSplitQuery()
                                             .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Product entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(entity);
        }

        public async Task Update(int id, Product entity)
        {
            var data = await Get(id);

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Title = entity.Title;
            data.Description = entity.Description;
            data.Images = entity.Images;
            data.Price = entity.Price;
            data.BathroomCount = entity.BathroomCount;
            data.BedroomCount = entity.BedroomCount;
            data.SquareFt = entity.SquareFt;
            data.Location = await _context.Locations.Where(n => n.Id == entity.LocationId).FirstOrDefaultAsync();
            data.LocationId = entity.LocationId;

            _context.Products.Update(data);
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
