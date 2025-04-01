using AutoMapper;
using OceanParadiseResort.Bedrooms.Application.Dtos;
using OceanParadiseResort.Bedrooms.Domain.Models;

namespace OceanParadiseResort.Bedrooms.Infra.Profiles
{
    public class BedroomProfile : Profile
    {
        public BedroomProfile()
        {
            CreateMap<CreateBedroomDto, Bedroom>();
            CreateMap<UpdateBedroomDto, Bedroom>();
            CreateMap<Bedroom, ReadBedroomDto>();
        }
    }
}
