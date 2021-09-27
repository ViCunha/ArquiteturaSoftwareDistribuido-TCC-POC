using AutoMapper;
using Identity.Domain.Models;
using Identity.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
