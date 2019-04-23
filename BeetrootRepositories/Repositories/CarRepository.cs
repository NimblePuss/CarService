using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetrootModels.Context;
using BeetrootModels.DbModels;
using BeetrootModels.Helpers;
using BeetrootRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeetrootRepository.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly BeetrootDbContext _db;

        public CarRepository(BeetrootDbContext context)
        {
            _db = context;
        }


        public async Task Edit(Car item)
        {
            var car = await _db.Cars.Where(c => c.Id == item.Id)
                                    .FirstOrDefaultAsync();

            if (car == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);


            car.Name = item.Name;
            car.Year = item.Year;

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> Find(Func<Car, bool> predicate)
        {
            return _db.Cars.Where(predicate);
        }

        public async Task<Car> GetById(int id)
        {
            return await _db.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetAll(int skip = 0, int take = 20)
        {
            return await _db.Cars.Skip(skip).Take(take).ToArrayAsync();
        }

        public async Task Remove(Car item)
        {
            _db.Cars.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var car = await GetById(id);
            if (car == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);
            await Remove(car);
        }

        public int Create(Car item)
        {
            _db.Cars.Add(item);
            _db.SaveChanges();

            return item.Id;
        }
    }
}
