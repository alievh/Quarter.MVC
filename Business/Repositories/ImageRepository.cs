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
    public class ImageRepository : IImageService
    {
        private readonly AppDbContext _context;

        public ImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Image> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Images.Where(n => n.Id == id).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Image>> GetAll()
        {
            var data = await _context.Images.ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Image entity)
        {
            await _context.Images.AddAsync(entity);
        }

        public async Task Update(int id, Image entity)
        {
            var data = await Get(id);

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            data.Url = entity.Url;
            data.Abouts = entity.Abouts;
            data.Services = entity.Services;
            data.Blogs = entity.Blogs;
            data.ApartmentPlans = entity.ApartmentPlans;
            data.Products = entity.Products;
        }

        public async Task Delete(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await Get(id);

            _context.Images.Remove(data);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
