using AutoMapper;
using OceanParadiseResort.Bedrooms.Data.Dtos;
using OceanParadiseResort.Bedrooms.Models;

namespace OceanParadiseResort.Bedrooms.Profiles
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
