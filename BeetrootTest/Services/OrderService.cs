using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeetrootApi.Interfaces;
using BeetrootModels.DbModels;
using BeetrootModels.DTO;
using BeetrootModels.Enums;
using BeetrootModels.Helpers;
using BeetrootRepository.Interfaces;
using BeetrootRepository.MapperProvider;

namespace BeetrootApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICarRepository _carRepository;
        private readonly IPersonalInfoRepository _personRepository;
        private readonly IAutoMapperProvider _mapper;

        public OrderService(
                IOrderRepository orderRepository,
                IAutoMapperProvider mapper,
                ICarRepository carRepository,
                IPersonalInfoRepository personRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _carRepository = carRepository;
            _personRepository = personRepository;
        }

        public async Task Create(NewOrderDTO item)
        {
            var personId =  _personRepository.Create(_mapper.Mapper.Map<PersonalInfo>(item.Person));
            var carId = _carRepository.Create(_mapper.Mapper.Map<Car>(item.Car));

            //didn't have time to make a correct record of services

            var order = new Order()
            {
                CarId = carId,
                PersonInfoId = personId,
                Message = item.Message,
                OrderDateCreate = DateTime.UtcNow,
                DateFrom = item.DateFrom,
                DateTo = item.DateTo
            };
            _orderRepository.Create(order);
        }

        public async Task Edit(OrderDTO item)
        {
            await _orderRepository.Edit(_mapper.Mapper.Map<Order>(item));
        }

        public async Task<IEnumerable<OrderDTO>> GetAll(int skip, int take)
        {
            var orders = await _orderRepository.GetAll(skip, take);
            return _mapper.Mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllServices(int id)
        {
            var services = await _orderRepository.GetAllServices(id);
            return _mapper.Mapper.Map<IEnumerable<ServiceDTO>>(services);
        }

        public async Task<OrderDTO> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return _mapper.Mapper.Map<OrderDTO>(order);
        }

        public async Task Remove(int id)
        {
            await _orderRepository.Remove(id);
        }
    }
}
