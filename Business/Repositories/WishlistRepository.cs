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
    public class WishlistRepository : IWishlistService
    {
        private readonly AppDbContext _context;

        public WishlistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Wishlist> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Wishlists.Where(n => n.Id == id).Where(n => !n.IsDeleted).Include(n => n.AppUser).Include(n => n.Products).ThenInclude(n => n.Images).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Wishlist>> GetAll()
        {
            var data = await _context.Wishlists.Where(n => !n.IsDeleted).Include(n => n.AppUser).Include(n => n.Products).ThenInclude(n => n.Images).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Wishlist entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Wishlists.AddAsync(entity);
        }

        public async Task Update(int id, Wishlist entity)
        {
            var data = await Get(id);

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Products = entity.Products;
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
