using BeetrootModels.DbModels;
using BeetrootRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeetrootRepository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
       Task<IEnumerable<Service>> GetAllServices(int orderId);
    }
}
