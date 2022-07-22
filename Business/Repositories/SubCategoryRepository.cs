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
    public class SubCategoryRepository : ISubCategoryService
    {
        private readonly AppDbContext _context;

        public SubCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubCategory> Get(int? id)
        {
            if(id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.SubCategories.Where(n => !n.IsDeleted)
                                                   .Where(n => n.Id == id)
                                                   .Include(n => n.Category)
                                                   .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<SubCategory>> GetAll()
        {
            var data = await _context.SubCategories.Where(n => !n.IsDeleted).Include(n => n.Category).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(SubCategory entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);
            entity.Category = entity.Category;
            entity.Name = entity.Name;

            await _context.SubCategories.AddAsync(entity);
        }

        public async Task Update(int id, SubCategory entity)
        {
            var data = await Get(id);

            data.Name = entity.Name;
            data.Category = entity.Category;
            data.UpdateDate = DateTime.UtcNow.AddHours(4);

            _context.SubCategories.Update(data);
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
