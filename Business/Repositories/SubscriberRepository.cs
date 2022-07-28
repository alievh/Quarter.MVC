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
    public class SubscriberRepository : ISubscriberService
    {
        private readonly AppDbContext _context;

        public SubscriberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subscriber> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Subscribers.Where(n => n.Id == id).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Subscriber>> GetAll()
        {
            var data = await _context.Subscribers.ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Subscriber entity)
        {
            await _context.Subscribers.AddAsync(entity);
        }

        public async Task Update(int id, Subscriber entity)
        {
            var data = await Get(id);

            data.SubscriberEmail = entity.SubscriberEmail;
            _context.Subscribers.Update(data);
        }

        public async Task Delete(int? id)
        {
            var data = await Get(id);

            _context.Subscribers.Remove(data);
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
