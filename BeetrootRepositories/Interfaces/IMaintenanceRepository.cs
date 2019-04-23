using BeetrootModels.DbModels;
using BeetrootRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeetrootRepository.Interfaces
{
    public interface IServiceRepository: IRepository<Service>
    {
    }
}
