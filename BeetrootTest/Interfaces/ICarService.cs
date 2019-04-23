using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetrootModels.DTO;

namespace BeetrootApi.Interfaces
{
    public interface ICarService
    {
        Task<CarDTO> GetById(int id);
        void Create(CarDTO item);
        Task Remove(CarDTO item);
        Task Edit(CarDTO item);

        Task<IEnumerable<CarDTO>> GetAll(int skip, int take);
    }
}
