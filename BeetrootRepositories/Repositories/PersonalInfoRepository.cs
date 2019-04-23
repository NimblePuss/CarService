using BeetrootModels.Context;
using BeetrootRepository.Interfaces;
using BeetrootModels.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetrootModels.Helpers;

namespace BeetrootRepository.Repositories
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        private readonly BeetrootDbContext _db;

        public PersonalInfoRepository(BeetrootDbContext context)
        {
            _db = context;
        }

        public int Create(PersonalInfo item)
        {
            _db.PersonInfos.AddAsync(item);
            _db.SaveChangesAsync();
            return item.Id;
        }

        public async Task Edit(PersonalInfo item)
        {
            var pi = _db.PersonInfos.Where(p => p.Id == item.Id)
                .FirstOrDefault();

            if (pi == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);


            pi.Email = item.Email;
            pi.FirstName = item.FirstName;
            pi.Phone = item.Phone;
            pi.SecondName = item.SecondName;

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonalInfo>> Find(Func<PersonalInfo, bool> predicate)
        {
            return _db.PersonInfos.Where(predicate);
        }

        public async Task<IEnumerable<PersonalInfo>> GetAll(int skip = 0, int take = 20)
        {
            return await _db.PersonInfos.Skip(skip).Take(take).ToArrayAsync();
        }

        public async Task<PersonalInfo> GetById(int id)
        {
            return await _db.PersonInfos.Where(pi => pi.Id == id).FirstAsync();
        }

        public async Task Remove(PersonalInfo item)
        {
            _db.PersonInfos.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var pi = await GetById(id);
            if (pi == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);
            await Remove(pi);
        }
    }
}
