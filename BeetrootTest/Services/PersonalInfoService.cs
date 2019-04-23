using System.Collections.Generic;
using System.Threading.Tasks;
using BeetrootApi.Interfaces;
using BeetrootModels.DbModels;
using BeetrootModels.DTO;
using BeetrootRepository.Interfaces;
using BeetrootRepository.MapperProvider;

namespace BeetrootApi.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IAutoMapperProvider _mapper;

        public PersonalInfoService(IPersonalInfoRepository personalInfoRepository, IAutoMapperProvider mapper)
        {
            _personalInfoRepository = personalInfoRepository;
            _mapper = mapper;
        }

        public void Create(PersonalInfoDTO item)
        {
             _personalInfoRepository.Create(_mapper.Mapper.Map<PersonalInfo>(item));
        }

        public async Task Edit(PersonalInfoDTO item)
        {
            await _personalInfoRepository.Edit(_mapper.Mapper.Map<PersonalInfo>(item));
        }

        public async Task<IEnumerable<PersonalInfoDTO>> GetAll(int skip, int take)
        {
            var piList = _mapper.Mapper.Map<IEnumerable<PersonalInfoDTO>>(await _personalInfoRepository.GetAll(skip, take));
            return piList;
        }

        public async Task<PersonalInfoDTO> GetById(int id)
        {
            return _mapper.Mapper.Map<PersonalInfoDTO>(await _personalInfoRepository.GetById(id));
        }

        public async Task Remove(int id)
        {
            await _personalInfoRepository.Remove(id);
        }
    }
}
