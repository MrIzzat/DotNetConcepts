using AutoMapper;
using AutoMapping.Entities.DTOs;

namespace AutoMapping.Entities.Mappers
{
    public class SuperHeroMapperProfile : Profile
    {
        public SuperHeroMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
            // CreateMap<Source,Destination>

            //CreateMap<SuperHeroDTO, SuperHero>();
            //Can do this but it's not needed if I use .ReverseMap()

        }
    }
}
