
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetrootModels.DTO;

namespace BeetrootApi.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> GetById(int id);
        Task Create(NewOrderDTO item);
        Task Remove(int id);
        Task Edit(OrderDTO item);

        Task<IEnumerable<OrderDTO>> GetAll(int skip, int take);
        Task<IEnumerable<ServiceDTO>> GetAllServices(int id);
    }
}
