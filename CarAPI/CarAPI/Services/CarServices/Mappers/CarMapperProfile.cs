using AutoMapper;
using CarAPI.Models;
using CarAPI.Models.DTO;

namespace CarAPI.Services.CarServices.Mappers
{
    public class CarMapperProfile : Profile
    {
        public CarMapperProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
        }
    }
}
