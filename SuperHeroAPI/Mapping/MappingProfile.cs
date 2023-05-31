using AutoMapper;
using SuperHeroAPI.DataTransferObjects;

namespace SuperHeroAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PowerUps, PowerUpsDTO>().ReverseMap();
        }
    }
}
