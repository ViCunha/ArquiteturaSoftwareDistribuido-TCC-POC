using AutoMapper;
using Identity.Domain.Models;
using Identity.Domain.Models.DTO;

namespace Identity.Application.Configure
{
    public class CustomerAutoMapperProfile : Profile
    {
        public CustomerAutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
