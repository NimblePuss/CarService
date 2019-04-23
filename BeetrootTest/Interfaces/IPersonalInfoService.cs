
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeetrootModels.DTO;

namespace BeetrootApi.Interfaces
{
    public interface IPersonalInfoService
    {
        Task<PersonalInfoDTO> GetById(int id);
        void Create(PersonalInfoDTO item);
        Task Remove(int id);
        Task Edit(PersonalInfoDTO item);

        Task<IEnumerable<PersonalInfoDTO>> GetAll(int skip, int take);
    }
}
