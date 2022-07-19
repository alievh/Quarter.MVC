using Business.Services;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class VideoRepository : IVideoService
    {
        public Task<Video> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Video>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Create(Video entity)
        {
            throw new NotImplementedException();
        }
        public Task Update(int id, Video entity)
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
