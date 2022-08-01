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
    public class BlogRepository : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Blogs.Where(n => !n.IsDeleted)
                                           .Where(n => n.Id == id)
                                           .Include(n => n.Images)
                                           .Include(n => n.BlogDetail)
                                           .Include(n => n.BlogCategories)
                                           .Include(n => n.Comments)
                                           .Include(n => n.AppUser)
                                           .ThenInclude(n => n.Image)
                                           .AsSplitQuery()
                                           .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Blog>> GetAll()
        {
            var data = await _context.Blogs.Where(n => !n.IsDeleted)
                                           .OrderByDescending(n => n.CreateDate)
                                           .Include(n => n.Images)
                                           .Include(n => n.BlogDetail)
                                           .Include(n => n.BlogCategories)
                                           .Include(n => n.Comments)
                                           .Include(n => n.AppUser)
                                           .ThenInclude(n => n.Image)
                                           .AsSplitQuery()
                                           .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Blog entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Blogs.AddAsync(entity);
        }

        public async Task Update(int id, Blog entity)
        {
            var data = await Get(id);

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Title = entity.Title;
            data.Description = entity.Description;
            data.Images = entity.Images;
            if (entity.Comments != null)
            {
                data.Comments = entity.Comments;
            }
            data.BlogDetail.Content = entity.BlogDetail.Content;

            _context.Blogs.Update(data);
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
