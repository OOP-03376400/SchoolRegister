using AutoMapper;
using SchoolRegister.Core.Domain;
using SchoolRegister.Infrastructure.DTO;

namespace SchoolRegister.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}