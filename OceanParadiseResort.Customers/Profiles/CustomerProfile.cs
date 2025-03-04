using AutoMapper;
using OceanParadiseResort.Customers.Data.Dtos;
using OceanParadiseResort.Customers.Models;

namespace OceanParadiseResort.Customers.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerDto, Customer>()
                .ForMember(c => c.Birthday, opt =>
                {
                    opt.MapFrom(dto => DateOnly.FromDateTime(dto.Birthday));
                }); 
        }
    }
}
