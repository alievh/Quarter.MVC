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
    public class BlogCategoryRepository : IBlogCategoryService
    {
        private readonly AppDbContext _context;

        public BlogCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogCategory> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("id");
            }

            var data = await _context.BlogCategories.Where(n => n.Id == id)
                                                    .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<BlogCategory>> GetAll()
        {
            var data = await _context.BlogCategories.ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(BlogCategory entity)
        {
            await _context.BlogCategories.AddAsync(entity);
        }

        public async Task Update(int id, BlogCategory entity)
        {
            var data = await Get(id);

            data.Name = entity.Name;

            _context.BlogCategories.Update(data);
        }

        public async Task Delete(int? id)
        {
            var data = await Get(id);

            _context.BlogCategories.Remove(data);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
