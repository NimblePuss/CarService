using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetrootModels.DTO;

namespace BeetrootApi.Interfaces
{
    public interface ISVCService
    {
        Task<ServiceDTO> GetById(int id);
        Task Create(ServiceDTO item);
        Task Remove(int id);
        Task Edit(ServiceDTO item);

        Task<IEnumerable<ServiceDTO>> GetAll(int skip, int take);
    }
}
