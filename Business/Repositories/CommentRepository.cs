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
    public class CommentRepository : ICommentService
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Comments.Where(n => !n.IsDeleted)
                                              .Where(n => n.Id == id)
                                              .Include(n => n.AppUser)
                                              .ThenInclude(n => n.Image)
                                              .Include(n => n.Product)
                                              .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Comment>> GetAll()
        {
            var data = await _context.Comments.Where(n => !n.IsDeleted)
                                              .Include(n => n.AppUser)
                                              .ThenInclude(n => n.Image)
                                              .Include(n => n.Product)
                                              .OrderByDescending(n => n.CreateDate)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Comment entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);

            await _context.Comments.AddAsync(entity);
        }

        public async Task Update(int id, Comment entity)
        {
            var data = await Get(id);

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Content = entity.Content;
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
