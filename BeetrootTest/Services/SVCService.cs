using BeetrootApi.Interfaces;
using BeetrootModels.DbModels;
using BeetrootModels.DTO;
using BeetrootRepository.Interfaces;
using BeetrootRepository.MapperProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeetrootApi.Services
{
    public class SVCService : ISVCService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IAutoMapperProvider _mapper;

        public SVCService(IServiceRepository serviceRepository, IAutoMapperProvider mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task Create(ServiceDTO item)
        {
             _serviceRepository.Create(_mapper.Mapper.Map<Service>(item));
        }

        public async Task Edit(ServiceDTO item)
        {
            await _serviceRepository.Edit(_mapper.Mapper.Map<Service>(item));
        }

        public async  Task<IEnumerable<ServiceDTO>> GetAll(int skip, int take)
        {
            var services = _mapper.Mapper.Map<IEnumerable<ServiceDTO>>(await _serviceRepository.GetAll(skip, take));
            return services;
        }

        public async Task<ServiceDTO> GetById(int id)
        {
            return _mapper.Mapper.Map<ServiceDTO>(await _serviceRepository.GetById(id));
        }

        public async Task Remove(int id)
        {
            await _serviceRepository.Remove(id);
        }
    }
}
