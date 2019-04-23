using BeetrootModels.Context;
using BeetrootRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeetrootModels.DbModels;
using BeetrootModels.Helpers;

namespace BeetrootRepository.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BeetrootDbContext _db;

        public ServiceRepository(BeetrootDbContext context)
        {
            _db = context;
        }

        public int Create(Service item)
        {
            _db.Services.AddAsync(item);
            _db.SaveChangesAsync();
            return item.Id;

        }

        public async Task Edit(Service item)
        {
            var service = _db.Services.Where(s => s.Id == item.Id)
               .FirstOrDefault();

            if (service == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);


            service.Name = item.Name;

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Service>> Find(Func<Service, bool> predicate)
        {
            return _db.Services.Where(predicate);
        }

        public async Task<IEnumerable<Service>> GetAll(int skip = 0, int take = 20)
        {
            return await _db.Services.Skip(skip).Take(take).ToArrayAsync();
        }

        public Task<Service> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Service item)
        {
            await _db.Services.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var service = await GetById(id);
            if (service == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);
            await Remove(service);
        }
    }
}
