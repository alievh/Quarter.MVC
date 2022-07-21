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
    public class BasketRepository : IBasketService
    {
        private readonly AppDbContext _context;

        public BasketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Basket> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Baskets.Where(n => !n.IsDeleted)
                                             .Where(n => n.Id == id)
                                             .Include(n => n.Products)
                                             .Include(n => n.AppUser)
                                             .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public Task<List<Basket>> GetAll()
        {
            var data = _context.Baskets.Where(n => !n.IsDeleted)
                                       .Include(n => n.Products)
                                       .Include(n => n.AppUser)
                                       .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Basket entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Baskets.AddAsync(entity);
        }

        public async Task Update(int id, Basket entity)
        {
            var data = await Get(id);

            if(data is null)
            {
                throw new EntityIsNullException();
            }

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Products = entity.Products;
            data.TotalPrice = entity.TotalPrice;
        }

        public async Task Delete(int? id)
        {
            var data = await Get(id);

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            data.IsDeleted = true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
