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
    public class AboutAboutRepository : IAboutAboutService
    {
        private readonly AppDbContext _context;

        public AboutAboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AboutAbout> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.AboutAbouts.Where(n => n.Id == id).Include(n => n.Image).Include(n=> n.AboutItems).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<AboutAbout>> GetAll()
        {
            var data = await _context.AboutAbouts.Include(n => n.Image).Include(n => n.AboutItems).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public Task Create(AboutAbout entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, AboutAbout entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
