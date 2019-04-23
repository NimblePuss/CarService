using System;
using AutoMapper;
using BeetrootModels.DbModels;
using BeetrootModels.DTO;

namespace BeetrootRepository.MapperProvider
{

    public interface IAutoMapperProvider
    {
        IMapper Mapper { get; }
    }

    public class AutoMapperProvider : IAutoMapperProvider
    {
        public IMapper Mapper
        {
            get
            {
                return new MapperConfiguration(map =>
                {
                    map.CreateMap<Service, ServiceDTO>().ReverseMap();
                    map.CreateMap<Car, CarDTO>().ReverseMap();
                    map.CreateMap<Order, OrderDTO>().ReverseMap();
                    map.CreateMap<PersonalInfo, PersonalInfoDTO>().ReverseMap();

                }).CreateMapper();
            }

        }
    }
}
