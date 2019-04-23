using BeetrootModels.Context;
using BeetrootModels.DbModels;
using BeetrootModels.Helpers;
using BeetrootRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeetrootRepository.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BeetrootDbContext _db;

        public OrderRepository(BeetrootDbContext context)
        {
            _db = context;
        }

        public int Create(Order item)
        {
            _db.Orders.AddAsync(item);
            _db.SaveChangesAsync();
            return item.Id;
        }

        public async Task Edit(Order item)
        {
            var order = _db.Orders.Where(c => c.Id == item.Id)
                 .FirstOrDefault();

            if (order == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);

            order.Message = item.Message;
            order.DateFrom = item.DateFrom;
            order.DateTo = item.DateTo;

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Find(Func<Order, bool> predicate)
        {
            return _db.Orders.Where(predicate);
        }

        public async Task<IEnumerable<Order>> GetAll(int skip = 0, int take = 20)
        {
            return await _db.Orders.Skip(skip).Take(take).ToArrayAsync();
        }

        public async Task<IEnumerable<Service>> GetAllServices(int orderId)
        {
            return await (from os in _db.OrderServices
                          join s in _db.Services on os.ServiceId equals s.Id
                          where os.OrderId == orderId
                          select s).ToArrayAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _db.Orders.Where(or => or.Id == id).FirstAsync();
        }



        public async Task Remove(Order item)
        {
            _db.Orders.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var order = await GetById(id);
            if (order == null) throw new BeetrootException(BeetrootModels.Enums.Error.DataNotFound);
            await Remove(order);
        }
    }
}
