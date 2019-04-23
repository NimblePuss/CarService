using System.Collections.Generic;
using System.Threading.Tasks;
using BeetrootApi.Interfaces;
using BeetrootModels.DbModels;
using BeetrootModels.DTO;
using BeetrootRepository.Interfaces;
using BeetrootRepository.MapperProvider;

namespace BeetrootApi.Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;
        private IAutoMapperProvider _mapper;

        public CarService(ICarRepository carRepository, IAutoMapperProvider mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public void Create(CarDTO car)
        {
           _carRepository.Create(_mapper.Mapper.Map<Car>(car));
        }

        public async Task Edit(CarDTO car)
        {
            await _carRepository.Edit(_mapper.Mapper.Map<Car>(car));
        }

        public async Task<IEnumerable<CarDTO>> GetAll(int skip = 0, int take = 20)
        {
            var cars = _mapper.Mapper.Map<IEnumerable<CarDTO>>(await _carRepository.GetAll(skip, take));
            return cars;
        }

        public async Task<CarDTO> GetById(int id)
        {
            var cars = _mapper.Mapper.Map<CarDTO>(await _carRepository.GetById(id));
            return cars;
        }

        public async Task Remove(CarDTO car)
        {
            await _carRepository.Remove(_mapper.Mapper.Map<Car>(car));
        }
       
    }
}
