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
    public class CategoryRepository : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Categories.Where(n => !n.IsDeleted)
                                                .Where(n => n.Id == id)
                                                .Include(n => n.Products)
                                                .Include(n => n.SubCategories)
                                                .FirstOrDefaultAsync();

            if(data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Category>> GetAll()
        {
            var data = await _context.Categories.Where(n => !n.IsDeleted)
                                                .Include(n => n.Products)
                                                .Include(n => n.SubCategories)
                                                .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Category entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);
            await _context.Categories.AddAsync(entity);

        }

        public async Task Update(int id, Category entity)
        {
            var data = await Get(id);

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Name = entity.Name;
            if(entity.SubCategories is not null)
            {
                data.SubCategories = entity.SubCategories;
            }
            if(entity.Products is not null)
            {
                data.Products = entity.Products;
            }

            _context.Categories.Update(data);
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
