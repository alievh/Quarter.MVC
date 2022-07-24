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
    public class FeedBackRepository : IFeedBackService
    {
        private readonly AppDbContext _context;

        public FeedBackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FeedBack> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.FeedBacks.Where(n => !n.IsDeleted)
                                                .Where(n => n.Id == id)
                                                .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;

        }

        public async Task<List<FeedBack>> GetAll()
        {
            var data = await _context.FeedBacks.Where(n => !n.IsDeleted)
                                                .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(FeedBack entity)
        {
            entity.CreateDate = DateTime.UtcNow.AddHours(4);
            await _context.FeedBacks.AddAsync(entity);
        }

        public async Task Update(int id, FeedBack entity)
        {
            var data = await Get(id);

            data.UpdateDate = DateTime.UtcNow.AddHours(4);
            data.Content = entity.Content;

            _context.FeedBacks.Update(data);
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
