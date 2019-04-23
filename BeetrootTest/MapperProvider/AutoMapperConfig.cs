using AutoMapper;
using BeetrootModels.DbModels;
using BeetrootModels.DTO;

namespace BeetrootApi.MapperProvider
{
    public class AutoMapperConfig
    {

        public static IMapper ConfigureAutoMapper()
        {
            IMapper mapper = new MapperConfiguration(map =>
            {
                map.CreateMap<ServiceDTO, Service>().ReverseMap();
                map.CreateMap<CarDTO, Car>().ReverseMap();
                map.CreateMap<OrderDTO, Order>().ReverseMap();
                map.CreateMap<PersonalInfoDTO, PersonalInfo>().ReverseMap();
                map.CreateMap<NewOrderDTO, Order>().ReverseMap();

            }).CreateMapper();

            return mapper;
        }
    }
}
